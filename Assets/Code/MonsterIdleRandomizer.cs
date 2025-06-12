using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class MonsterChasePlayer : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float stopDistance = 1.5f;
    public float moveSpeed = 2f;

    public AudioClip attackSound1;
    public AudioClip attackSound2;
    public GameObject attackZone;

    public int health = 100;

    private Animator animator;
    private Rigidbody rb;
    private AudioSource audioSource;

    private bool isChasing = false;
    private bool isInAttack = false;
    private int currentIdle = -1;

    [Header("Drop Items")]
    public GameObject[] dropPrefabs; // 允许指定多个掉落物体


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rb.useGravity = true;
        rb.isKinematic = false;

        if (attackZone != null)
            attackZone.SetActive(false);

        PrintAnimatorParameters();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < stopDistance)
        {
            if (!isInAttack)
            {
                animator.SetBool("IsRunning", false);
                isInAttack = true;
                isChasing = false;

                int atk = Random.Range(1, 3);
                string trigger = $"attack{atk}Trigger";
                animator.SetTrigger(trigger);
                Debug.Log($"🗡️ 怪物进入攻击距离，触发动画：{trigger}");
            }
            return;
        }

        if (distance < detectionRange)
        {
            if (!isChasing)
            {
                animator.SetBool("IsRunning", true);
                isChasing = true;
                isInAttack = false;
                Debug.Log("🚨 玩家进入中距离，怪物开始追踪");
            }

            // ✅ 防止被子弹推动
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 moveTarget = transform.position + direction * moveSpeed * Time.deltaTime;
            rb.MovePosition(moveTarget);

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        else
        {
            if (isChasing || isInAttack)
            {
                animator.SetBool("IsRunning", false);
                isChasing = false;
                isInAttack = false;
                Debug.Log("🧊 玩家离开范围 → 回到随机待机");
                TriggerRandomIdle();
            }
        }
    }

    void TriggerRandomIdle()
    {
        int nextIdle;
        do
        {
            nextIdle = Random.Range(1, 4);
        } while (nextIdle == currentIdle);

        currentIdle = nextIdle;
        string triggerName = $"Idle{nextIdle}Trigger";

        Debug.Log($"🎯 随机待机动画：{triggerName}");
        animator.SetTrigger(triggerName);
    }

    void PrintAnimatorParameters()
    {
        Debug.Log("📋 当前 Animator 参数：");
        foreach (var p in animator.parameters)
        {
            Debug.Log($" - {p.name} ({p.type})");
        }
    }

    public void PlayAttackSound1()
    {
        if (attackSound1 != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound1);
            Debug.Log("🔊 播放 Attack 1 音效！");
        }
    }

    public void PlayAttackSound2()
    {
        if (attackSound2 != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound2);
            Debug.Log("🔊 播放 Attack 2 音效！");
        }
    }

    public void EnableAttackZone()
    {
        if (attackZone != null)
        {
            attackZone.SetActive(true);
            Debug.Log("🟥 攻击区域启用！");
        }
    }

    public void DisableAttackZone()
    {
        if (attackZone != null)
        {
            attackZone.SetActive(false);
            Debug.Log("⬜ 攻击区域禁用！");
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"💥 怪物受伤，当前血量：{health}");

        if (health <= 0)
        {
            Debug.Log("☠️ 怪物死亡！");

            // 💎 生成掉落物体
            if (dropPrefabs != null && dropPrefabs.Length > 0)
            {
                int index = Random.Range(0, dropPrefabs.Length);  // 随机索引
                GameObject drop = dropPrefabs[index];
                Instantiate(drop, transform.position, Quaternion.identity);
                Debug.Log($"🎁 掉落了：{drop.name}");
            }


            Destroy(gameObject);
        }
    }

}

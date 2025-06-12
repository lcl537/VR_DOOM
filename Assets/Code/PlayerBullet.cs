using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MonsterChasePlayer monster = other.GetComponent<MonsterChasePlayer>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
                Debug.Log($"💥 子弹触发命中怪物，造成 {damage} 点伤害！");
            }
        }

        Destroy(gameObject);
    }
}

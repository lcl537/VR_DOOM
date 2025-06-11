using UnityEngine;

public class MonsterAttackZone : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 查找 UIStatusManager 并执行扣血
            UIStatusManager statusManager = other.GetComponentInChildren<UIStatusManager>();
            if (statusManager != null)
            {
                statusManager.ChangeHealth(-damageAmount);
                Debug.Log("💥 玩家进入攻击范围，扣血：" + damageAmount);
            }
            else
            {
                Debug.LogWarning("❗ 玩家没有挂载 UIStatusManager 脚本！");
            }
        }
    }
}

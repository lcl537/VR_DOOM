using UnityEngine;

public class MonsterAttackZone : MonoBehaviour
{
    public int totalDamage = 20;  // 怪物总伤害量

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 查找 UIStatusManager
            UIStatusManager statusManager = other.GetComponentInChildren<UIStatusManager>();
            if (statusManager != null)
            {
                int currentArmor = statusManager.GetArmor();  // 读取当前护甲值

                if (currentArmor > 0)
                {
                    // 有护甲，护甲扣10，血量扣10
                    statusManager.ChangeArmor(-10);
                    statusManager.ChangeHealth(-10);
                    Debug.Log("💥 有护甲：护甲 -10，血量 -10");
                }
                else
                {
                    // 没护甲，血量直接扣20
                    statusManager.ChangeHealth(-totalDamage);
                    Debug.Log("💥 无护甲：血量 -20");
                }
            }
            else
            {
                Debug.LogWarning("❗ 玩家没有挂载 UIStatusManager 脚本！");
            }
        }
    }
}


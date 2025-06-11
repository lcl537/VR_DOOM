using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 20;  // ✅ 子弹造成的伤害

    void OnCollisionEnter(Collision collision)
    {
        // ✅ 使用标签检查是否为怪物
        if (collision.gameObject.CompareTag("Enemy"))
        {
            MonsterChasePlayer monster = collision.gameObject.GetComponent<MonsterChasePlayer>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
                Debug.Log($"💥 子弹命中怪物（标签检测），造成 {damage} 点伤害！");
            }
        }

        // ✅ 命中后销毁子弹
        Destroy(gameObject);
    }
}

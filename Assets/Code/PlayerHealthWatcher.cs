using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthWatcher : MonoBehaviour
{
    public UIStatusManager statusManager;  // 玩家血量管理器引用
    public string gameOverSceneName = "GameOverScene";  // 要跳转的场景名
    private bool isDead = false;

    void Start()
    {
        if (statusManager == null)
        {
            statusManager = GetComponentInChildren<UIStatusManager>();
        }

        if (statusManager == null)
        {
            Debug.LogError("❌ 没有找到 UIStatusManager，请手动绑定！");
        }
    }

    void Update()
    {
        if (isDead || statusManager == null) return;

        if (statusManager.GetHealth() <= 0)
        {
            isDead = true;
            Debug.Log("☠️ 玩家死亡，切换到死亡场景！");
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}

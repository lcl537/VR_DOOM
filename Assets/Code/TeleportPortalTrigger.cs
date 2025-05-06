using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPortalTrigger : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "SampleScene";

    private void OnTriggerEnter(Collider other)
    {
        // 碰撞检测角色
        if (other.CompareTag("Player"))
        {
            // 加载目标场景
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

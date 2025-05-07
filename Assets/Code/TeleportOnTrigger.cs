using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportSwitch : MonoBehaviour
{
    // 设置两个场景的名字
    [SerializeField] private string sceneA = "SampleScene";
    [SerializeField] private string sceneB = "RoomA";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 获取当前场景名字
            string currentScene = SceneManager.GetActiveScene().name;

            // 判断当前在哪个场景，传送到另一个场景
            if (currentScene == sceneA)
            {
                SceneManager.LoadScene(sceneB);
            }
            else if (currentScene == sceneB)
            {
                SceneManager.LoadScene(sceneA);
            }
            else
            {
                Debug.LogWarning("当前场景不在传送列表中！");
            }
        }
    }
}

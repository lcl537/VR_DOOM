using UnityEngine;

public class ExploreData : MonoBehaviour
{
    public static ExploreData Instance;

    public float exploreRate = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 保持跨场景存在
        }
        else
        {
            Destroy(gameObject); // 防止重复
        }
    }

    public void SetExplore(float value)
    {
        exploreRate = value;
    }

    public float GetExplore()
    {
        return exploreRate;
    }
}

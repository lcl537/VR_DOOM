using UnityEngine;
using TMPro;

public class ExploreResultUI : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    void Start()
    {
        if (ExploreData.Instance != null)
        {
            float explore = ExploreData.Instance.GetExplore();
            resultText.text = $"Explore: {explore:F2}%";
        }
        else
        {
            resultText.text = "Explore: N/A";
        }
    }
}

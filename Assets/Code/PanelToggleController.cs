using UnityEngine;
using UnityEngine.InputSystem;

public class PanelToggleController : MonoBehaviour
{
    [Header("面板对象")]
    public GameObject panel1;
    public GameObject panel2;

    [Header("输入动作")]
    public InputActionReference togglePanelAction;

    private bool isVisible = false;

    void Start()
    {
        // 默认隐藏面板
        panel1.SetActive(false);
        panel2.SetActive(false);

        // 启用 Input Action
        togglePanelAction.action.Enable();
    }

    void Update()
    {
        // 使用绑定的 Input Action 来检测按键
        if (togglePanelAction.action.triggered)
        {
            isVisible = !isVisible;
            panel1.SetActive(isVisible);
            panel2.SetActive(isVisible);
        }
    }
}

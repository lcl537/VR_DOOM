using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class UIStatusManager : MonoBehaviour
{
    [Header("UI Text References")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI exploreText;

    [Header("Input Actions (InputActionReference)")]
    public InputActionReference decreaseHealthAction;
    public InputActionReference increaseHealthAction;
    public InputActionReference decreaseAmmoAction;
    public InputActionReference increaseAmmoAction;
    public InputActionReference decreaseArmorAction;
    public InputActionReference increaseArmorAction;
    public InputActionReference increaseExploreAction;

    // 状态数值
    private int health = 100;
    private int ammo = 50;
    private int armor = 20;
    private float exploreRate = 0f;

    void Start()
    {
        // 启用所有 InputActionReference 的 action
        decreaseHealthAction.action.Enable();
        increaseHealthAction.action.Enable();
        decreaseAmmoAction.action.Enable();
        increaseAmmoAction.action.Enable();
        decreaseArmorAction.action.Enable();
        increaseArmorAction.action.Enable();
        increaseExploreAction.action.Enable();

        UpdateUI();
    }

    void Update()
    {
        if (decreaseHealthAction.action.triggered)
        {
            health = Mathf.Max(0, health - 10);
            UpdateUI();
        }

        if (increaseHealthAction.action.triggered)
        {
            health = Mathf.Min(100, health + 10);
            UpdateUI();
        }

        if (decreaseAmmoAction.action.triggered)
        {
            ammo = Mathf.Max(0, ammo - 5);
            UpdateUI();
        }

        if (increaseAmmoAction.action.triggered)
        {
            ammo += 5;
            UpdateUI();
        }

        if (decreaseArmorAction.action.triggered)
        {
            armor = Mathf.Max(0, armor - 5);
            UpdateUI();
        }

        if (increaseArmorAction.action.triggered)
        {
            armor += 5;
            UpdateUI();
        }

        if (increaseExploreAction.action.triggered)
        {
            exploreRate = Mathf.Min(100f, exploreRate + 5f);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        healthText.text = "Health: " + health;
        ammoText.text = "Ammo: " + ammo;
        armorText.text = "Armor: " + armor;
        exploreText.text = "Explore: " + exploreRate + "%";
    }
}

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
            ChangeHealth(-10);
        }

        if (increaseHealthAction.action.triggered)
        {
            ChangeHealth(10);
        }

        if (decreaseAmmoAction.action.triggered)
        {
            ChangeAmmo(-5);
        }

        if (increaseAmmoAction.action.triggered)
        {
            ChangeAmmo(5);
        }

        if (decreaseArmorAction.action.triggered)
        {
            ChangeArmor(-5);
        }

        if (increaseArmorAction.action.triggered)
        {
            ChangeArmor(5);
        }

        if (increaseExploreAction.action.triggered)
        {
            ChangeExplore(5f);
        }
    }

    // 公共加减方法（供按键和触碰调用）
    public void ChangeHealth(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, 100);
        UpdateUI();
    }

    public void ChangeAmmo(int amount)
    {
        ammo = Mathf.Max(0, ammo + amount);
        UpdateUI();
    }

    public void ChangeArmor(int amount)
    {
        armor = Mathf.Max(0, armor + amount);
        UpdateUI();
    }

    public void ChangeExplore(float amount)
    {
        exploreRate = Mathf.Min(100f, exploreRate + amount);
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = "Health: " + health;
        ammoText.text = "Ammo: " + ammo;
        armorText.text = "Armor: " + armor;
        exploreText.text = "Explore: " + exploreRate + "%";
    }

    // 拾取道具时调用
    public void PickupItem(string type, int amount)
    {
        switch (type)
        {
            case "Health":
                ChangeHealth(amount);
                break;
            case "Ammo":
                ChangeAmmo(amount);
                break;
            case "Armor":
                ChangeArmor(amount);
                break;
            case "Explore":
                ChangeExplore(amount);
                break;
        }
    }
}

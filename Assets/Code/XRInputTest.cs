using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[System.Serializable]
public class GunConfig
{
    public GameObject gunObject;            // 枪的 GameObject
    public GameObject muzzleFlashPrefab;    // 枪的 muzzle flash
    public Transform muzzlePoint;           // 发射点
    public GameObject bulletPrefab;         // 子弹预制体（每把枪可以不同）
    public float fireRate = 0.1f;           // 开火间隔（越小越快）
    public float bulletSpeed = 50f;         // 子弹速度
}

public class XRInputTest : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference testValue;  // Trigger：开火
    public InputActionReference testGrip;   // Grip：切换武器

    [Header("Weapons")]
    public List<GunConfig> gunConfigs;      // 所有武器配置
    private int currentGunIndex = 0;

    private float fireTimer = 0f;
    private bool isFiring = false;

    void Start()
    {
        testValue.action.performed += ctx => isFiring = true;
        testValue.action.canceled += ctx => isFiring = false;
        testValue.action.Enable();

        testGrip.action.performed += ctx => SwitchGun();
        testGrip.action.Enable();

        ActivateGun(currentGunIndex);
    }

    void Update()
    {
        if (isFiring)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f)
            {
                Fire();
                fireTimer = GetCurrentGun().fireRate;
            }
        }
    }

    private void Fire()
    {
        GunConfig gun = GetCurrentGun();

        if (gun.muzzleFlashPrefab != null && gun.muzzlePoint != null)
        {
            GameObject flash = Instantiate(gun.muzzleFlashPrefab, gun.muzzlePoint.position, gun.muzzlePoint.rotation);
            Destroy(flash, 1f);
        }

        if (gun.bulletPrefab != null && gun.muzzlePoint != null)
        {
            GameObject bullet = Instantiate(gun.bulletPrefab, gun.muzzlePoint.position, gun.muzzlePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = gun.muzzlePoint.forward * gun.bulletSpeed;
            }
            Destroy(bullet, 3f);
        }

        Debug.Log("Fire!");
    }

    private void SwitchGun()
    {
        currentGunIndex = (currentGunIndex + 1) % gunConfigs.Count;
        ActivateGun(currentGunIndex);
        Debug.Log("Switched to gun: " + currentGunIndex);
    }

    private void ActivateGun(int index)
    {
        for (int i = 0; i < gunConfigs.Count; i++)
        {
            gunConfigs[i].gunObject.SetActive(i == index);
        }
    }

    private GunConfig GetCurrentGun()
    {
        return gunConfigs[currentGunIndex];
    }
}

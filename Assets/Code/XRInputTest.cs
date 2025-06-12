using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[System.Serializable]
public class GunConfig
{
    public GameObject gunObject;
    public GameObject muzzleFlashPrefab;
    public Transform muzzlePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.1f;
    public float bulletSpeed = 50f;
    public AudioClip gunshotSound;
}

public class XRInputTest : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference testValue;
    public InputActionReference testGrip;

    [Header("Weapons")]
    public List<GunConfig> gunConfigs;
    private int currentGunIndex = 0;

    [Header("Audio")]
    public AudioSource gunAudioSource;  // 手动挂载的音效播放器

    private float fireTimer = 0f;
    private bool isFiring = false;

    private UIStatusManager uiStatusManager;

    void Start()
    {
        testValue.action.performed += ctx => isFiring = true;
        testValue.action.canceled += ctx => isFiring = false;
        testValue.action.Enable();

        testGrip.action.performed += ctx => SwitchGun();
        testGrip.action.Enable();

        ActivateGun(currentGunIndex);

        uiStatusManager = FindFirstObjectByType<UIStatusManager>();
        if (uiStatusManager == null)
        {
            Debug.LogWarning("未找到 UIStatusManager，弹药系统将无法工作！");
        }

        if (gunAudioSource == null)
        {
            Debug.LogWarning("未挂载 gunAudioSource！");
        }
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
        if (uiStatusManager == null)
        {
            Debug.LogWarning("UIStatusManager 未设置！");
            return;
        }

        if (GetAmmo() <= 0)
        {
            Debug.Log("子弹不足！");
            return;
        }

        GunConfig gun = GetCurrentGun();

        if (gun.muzzleFlashPrefab != null && gun.muzzlePoint != null)
        {
            GameObject flash = Instantiate(gun.muzzleFlashPrefab, gun.muzzlePoint.position, gun.muzzlePoint.rotation);
            Destroy(flash, 1f);
        }

        if (gun.bulletPrefab != null && gun.muzzlePoint != null)
        {
            GameObject bullet = Instantiate(gun.bulletPrefab, gun.muzzlePoint.position, gun.muzzlePoint.rotation);

            BulletFly fly = bullet.GetComponent<BulletFly>();
            if (fly != null)
            {
                fly.speed = gun.bulletSpeed;
            }

            Destroy(bullet, 3f);
        }

        if (gun.gunshotSound != null && gunAudioSource != null)
        {
            gunAudioSource.PlayOneShot(gun.gunshotSound);
        }

        Debug.Log("Fire!");
        uiStatusManager.ChangeAmmo(-1);
    }

    private int GetAmmo()
    {
        return uiStatusManager.GetAmmo();
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

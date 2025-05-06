using UnityEngine;
using UnityEngine.InputSystem;

public class XRInputTest : MonoBehaviour
{
    public InputActionReference testValue; 
    public GameObject muzzleFlashPrefab;   
    public Transform muzzlePoint;          

    public float fireRate = 0.1f; 
    private float fireTimer = 0f;
    private bool isFiring = false;

    void Start()
    {
        testValue.action.performed += ctx => isFiring = true;    
        testValue.action.canceled += ctx => isFiring = false;    
        testValue.action.Enable();
    }

    void Update()
    {
        if (isFiring)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f)
            {
                Fire();
                fireTimer = fireRate;
            }
        }
    }

    private void Fire()
    {
        if (muzzleFlashPrefab != null && muzzlePoint != null)
        {
            GameObject flash = Instantiate(muzzleFlashPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Destroy(flash, 1f); 
        }
        Debug.Log("Fire!");
    }
}

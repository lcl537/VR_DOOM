using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       

        Destroy(gameObject);
    }
}

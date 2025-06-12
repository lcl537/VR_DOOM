using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float speed = 50f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
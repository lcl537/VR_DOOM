using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public int amount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIStatusManager status = other.GetComponent<UIStatusManager>();
            if (status != null)
            {
                string tag = gameObject.tag;

                switch (tag)
                {
                    case "Health":
                        status.PickupItem("Health", amount);
                        break;
                    case "Ammo":
                        status.PickupItem("Ammo", amount);
                        break;
                    case "Armor":
                        status.PickupItem("Armor", amount);
                        break;
                    default:
                        Debug.LogWarning("Unrecognized pickup tag: " + tag);
                        break;
                }
            }

            Destroy(gameObject);
        }
    }
}

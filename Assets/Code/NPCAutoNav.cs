using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public Transform playerTransform;

    [SerializeField] Vector3 offset = Vector3.back;
    [SerializeField] float distance = 3;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void follwoPlayer()
    {
        if (playerTransform == null) return;

        offset = -playerTransform.forward * distance;

        Vector3 targetPos = playerTransform.position + offset;
        targetPos.y = transform.position.y;

        agent.destination = targetPos;
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        if (playerTransform)
        {
            follwoPlayer();
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();

            checkSurround(transform.position, 5); // ·¶Î§
        }
    }

    void checkSurround(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player")) // Ê¹ÓÃ Tag
            {
                playerTransform = hitCollider.transform;
                break;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public Transform playerTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        // 确保由 NavMeshAgent 控制转向和移动
        agent.updateRotation = true;
        agent.updatePosition = true;

        GotoNextPoint();
    }

    void FollowPlayer()
    {
        if (playerTransform == null) return;

        // 直接设置目标位置，NavMeshAgent 会自动转向
        agent.SetDestination(playerTransform.position);
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.SetDestination(points[destPoint].position);
        destPoint = (destPoint + 1) % points.Length;
    }

    void Update()
    {
        if (playerTransform)
        {
            FollowPlayer();
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();

            CheckSurround(transform.position, 5); // 5米感知范围
        }
    }

    void CheckSurround(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                playerTransform = hitCollider.transform;
                break;
            }
        }
    }
}

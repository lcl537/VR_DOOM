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

        // ȷ���� NavMeshAgent ����ת����ƶ�
        agent.updateRotation = true;
        agent.updatePosition = true;

        GotoNextPoint();
    }

    void FollowPlayer()
    {
        if (playerTransform == null) return;

        // ֱ������Ŀ��λ�ã�NavMeshAgent ���Զ�ת��
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

            CheckSurround(transform.position, 5); // 5�׸�֪��Χ
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

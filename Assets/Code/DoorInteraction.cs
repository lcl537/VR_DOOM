using UnityEngine;
using UnityEngine.InputSystem;

public class DoorInteraction : MonoBehaviour
{
    public float moveDistance = 3f;      // 门上移的距离
    public float moveDuration = 1f;      // 运动时间（秒）
    public Transform player;             // 玩家 Transform，用于检测距离
    public float interactDistance = 3f;  // 可交互距离
    public InputActionReference interactAction;  // 从 InputActions 引用进来

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isMoving = false;
    private float elapsed = 0f;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance;

        if (interactAction != null)
            interactAction.action.performed += OnInteract;
    }

    void OnDestroy()
    {
        if (interactAction != null)
            interactAction.action.performed -= OnInteract;
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        if (isMoving) return;

        // 距离检测
        if (player != null && Vector3.Distance(transform.position, player.position) > interactDistance)
            return;

        isMoving = true;
        elapsed = 0f;
    }

    void Update()
    {
        if (isMoving)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            if (t >= 1f)
                isMoving = false;
        }
    }
}

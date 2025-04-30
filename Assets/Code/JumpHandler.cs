using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class JumpHandler : MonoBehaviour
{
    public InputActionReference jumpAction;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private CharacterController controller;
    private float verticalVelocity = 0f;
    private bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        jumpAction.action.performed += OnJump;
    }

    void OnEnable()
    {
        jumpAction.action.Enable();
    }

    void OnDisable()
    {
        jumpAction.action.Disable();
    }

    void Update()
    {
        isGrounded = CheckGrounded();

        if (isGrounded && verticalVelocity < 0)
            verticalVelocity = -1f; 

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 verticalMove = new Vector3(0, verticalVelocity, 0);
        controller.Move(verticalMove * Time.deltaTime);
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (CheckGrounded()) 
        {
            verticalVelocity = jumpForce;
        }
    }

    /// <summary>
  
    /// </summary>
    bool CheckGrounded()
    {
        if (controller.isGrounded)
            return true;

        Vector3 rayStart = transform.position + Vector3.up * 0.1f;
        bool hit = Physics.Raycast(rayStart, Vector3.down, groundCheckDistance + 0.1f, groundLayer);
        Debug.DrawRay(rayStart, Vector3.down * (groundCheckDistance + 0.1f), hit ? Color.green : Color.red);
        return hit;
    }
}

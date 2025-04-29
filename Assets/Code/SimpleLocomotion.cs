using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleLocomotion : MonoBehaviour
{
    public float moveSpeed = 2f;
    private CharacterController characterController;
    private Vector2 moveInput;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = Camera.main.transform.TransformDirection(move);
        move.y = 0; // 保持水平
        characterController.Move(move * moveSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
    }
}


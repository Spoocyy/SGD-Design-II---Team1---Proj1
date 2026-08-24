//Erik Robertson
//8/24/2026
//SGD Design II - Project 1 - Team 1
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls input;
    Rigidbody rb;
    Vector2 moveDirection;
    [SerializeField] float speed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerControls();

        //Input activations that relate to PlayerActions map
        input.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => moveDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        //Direction relative to the player
        Vector3 localDirection = new Vector3(moveDirection.x, 0f, moveDirection.y).normalized;

        //Same Vector converted to world space
        Vector3 direction = transform.TransformDirection(localDirection);

        //Physically moves the player using the Rigidbody
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}

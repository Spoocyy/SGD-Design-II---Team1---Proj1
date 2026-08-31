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
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float sphereCastRadius = 0.4f;
    [SerializeField] float sphereCastDistance = 0.6f;
    [SerializeField] Vector3 sphereCastOriginOffset = Vector3.zero;
    [SerializeField] LayerMask groundLayer;

    private bool jumpRequested;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerControls();

        //Input activations that relate to PlayerActions map
        input.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => moveDirection = Vector2.zero;
        input.Player.Jump.performed += ctx => jumpRequested = true;
    }

    private void FixedUpdate()
    {
        //Direction relative to the player
        Vector3 localDirection = new Vector3(moveDirection.x, 0f, moveDirection.y).normalized;

        //Same Vector converted to world space
        Vector3 direction = transform.TransformDirection(localDirection);

        //Physically moves the player using the Rigidbody
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);

        CheckGrounded();

        if(jumpRequested && isGrounded)
        {
            ApplyJump();
        }
        jumpRequested = false;

        Debug.Log($"Pos: {rb.position} | Vel: {rb.linearVelocity}");
    }

    //Cast a sphere downward from the player to detect if they're touching the ground
    private void CheckGrounded()
    {
        Vector3 origin = transform.position + sphereCastOriginOffset;

        //Sphere cast is more forgiving than a raycast near edges
        isGrounded = Physics.SphereCast(
            origin,
            sphereCastRadius,
            Vector3.down,
            out RaycastHit hit,
            sphereCastDistance,
            groundLayer
        );
    }

    private void ApplyJump()
    {
        //Reset vertical velocity first so jump height is consistent
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    //Method to show the SphereCast even in the editor
    private void OnDrawGizmosSelected()
    {

        Vector3 origin = transform.position + sphereCastOriginOffset;
        Vector3 endPoint = origin + Vector3.down * sphereCastDistance;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(origin, sphereCastRadius);

        //Show the difference between grounded or not grounded with the gizmo
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(endPoint, sphereCastRadius);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(origin, endPoint);

        //Physically shows the sphere in the editor so we can see and change its position if needed
        //Gizmos.DrawWireSphere(origin + Vector3.down * sphereCastDistance, sphereCastRadius);
    }
}

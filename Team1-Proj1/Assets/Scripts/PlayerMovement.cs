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

        input.Player.Move.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => moveDirection = Vector2.zero;
    }
}

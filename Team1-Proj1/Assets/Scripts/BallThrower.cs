//Erik Robertson
//8/26/2026
//SGD Design II - Project 1 - Team 1
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallThrower : MonoBehaviour
{
    [SerializeField] Transform throwPoint;
    [SerializeField] GameObject ballPrefab;

    [SerializeField] float throwForce = 10f;
    [SerializeField] float arcHeight = 0.3f;
    [SerializeField] Transform cameraTransform;
    private Vector3 throwDirection;

    PlayerControls input;

    private void Start()
    {
        SpawnBall();
    }

    private void Awake()
    {
        input = new PlayerControls();
    }

    private void SpawnBall()
    {
        ballPrefab = Instantiate(ballPrefab, throwPoint.position, throwPoint.rotation);
        ballPrefab.transform.SetParent(throwPoint);
        ballPrefab.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void ThrowBall()
    {
        throwDirection = cameraTransform.forward;
        throwDirection.y = 0;
        throwDirection.Normalize();
        throwDirection += Vector3.up * arcHeight;
        throwDirection.Normalize();

        Rigidbody rb = ballPrefab.GetComponent<Rigidbody>();
        ballPrefab.transform.SetParent(null);
        rb.isKinematic = false;
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        Destroy(ballPrefab, 60f);

        StartCoroutine(RespawnAfterDelay(1f));
    }

    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnBall();
    }

    private void OnThrowPerformed(InputAction.CallbackContext context)
    {
        ThrowBall();
    }

    private void OnEnable()
    {
        input.Player.Throw.performed += OnThrowPerformed;
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Throw.performed -= OnThrowPerformed;
        input.Player.Disable();
    }


}

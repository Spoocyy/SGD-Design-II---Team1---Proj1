using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    [SerializeField] float respawnDelay = 2f;

    public void HandleDeath()
    {
        //death animation and sound effect

        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        playerHealth.ResetHealth();
    }
}

using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHealth>(out var health))
        {
            health.Kill();
        }
    }
}

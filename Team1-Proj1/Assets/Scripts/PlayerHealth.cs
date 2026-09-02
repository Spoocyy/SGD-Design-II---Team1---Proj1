using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] HealthUI healthUI;
    [SerializeField] PlayerRespawn playerRespawn;

    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Start()
    {
        healthUI.UpdateBar(CurrentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        if (CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
        healthUI.UpdateBar(CurrentHealth, maxHealth);

        if (CurrentHealth == 0)
        {
            playerRespawn.HandleDeath();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = maxHealth;
        healthUI.UpdateBar(CurrentHealth, maxHealth);
    }
}

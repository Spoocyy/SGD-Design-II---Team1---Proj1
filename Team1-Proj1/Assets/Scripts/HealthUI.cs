using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    public void UpdateBar(int current, int max)
    {
        healthBar.maxValue = max;
        healthBar.value = current;
    }
}

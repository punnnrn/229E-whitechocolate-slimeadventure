using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void UpdateHealthText(int currentHealth, int maxHealth)
    {
        healthText.text = $"HP: {currentHealth} / {maxHealth}";
    }
}
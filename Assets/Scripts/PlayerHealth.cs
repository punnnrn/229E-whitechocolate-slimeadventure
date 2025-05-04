using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public PlayerHealthUI healthUI;

    void Start()
    {
        currentHealth = maxHealth;
        healthUI?.UpdateHealthText(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player took damage: " + damage + " | Current Health: " + currentHealth);
        healthUI?.UpdateHealthText(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
    }
}
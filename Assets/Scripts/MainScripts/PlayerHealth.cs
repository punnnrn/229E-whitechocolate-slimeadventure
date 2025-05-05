using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Audio")]
    public AudioClip hitSound;
    private AudioSource audioSource;

    [Header("UI")]
    public PlayerHealthUI healthUI;

    [Header("Visual Feedback")]
    public SpriteRenderer spriteRenderer;
    public Color hurtColor = Color.red;
    public float flashDuration = 0.2f;

    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;
        healthUI?.UpdateHealthText(currentHealth, maxHealth);
        audioSource = GetComponent<AudioSource>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player took damage: " + damage + " | Current Health: " + currentHealth);
        healthUI?.UpdateHealthText(currentHealth, maxHealth);

        if (hitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (spriteRenderer != null)
        {
            StartCoroutine(FlashColor());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        SceneManager.LoadScene("LoseScene");
    }

    System.Collections.IEnumerator FlashColor()
    {
        spriteRenderer.color = hurtColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }
}

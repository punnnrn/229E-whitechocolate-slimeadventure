using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 25;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyBullet"), LayerMask.NameToLayer("Bullet"), true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        PlayerHealth enemy = collision.gameObject.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // ลบกระสุนออก
        }
    }
}

using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 25;

    //ป้องกันการชน
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyBullet"), LayerMask.NameToLayer("Bullet"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("EnemyBullet"), LayerMask.NameToLayer("Pendulum"), true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(gameObject);
        }

        PlayerHealth enemy = collision.gameObject.GetComponent<PlayerHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

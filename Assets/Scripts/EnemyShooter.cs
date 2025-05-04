using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] Transform shootPoint;
    [SerializeField] Rigidbody2D bulletPrefab;
    [SerializeField] float cooldownTime = 1f;
    [SerializeField] float shootForceTime = 1f; // เวลาเดินทางของกระสุน
    [SerializeField] float attackRange = 10f;

    private float lastFireTime = -Mathf.Infinity;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        // ป้องกันกระสุนชนศัตรูตัวเองหรือผู้ยิง
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Bullet"), true);
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange && Time.time >= lastFireTime + cooldownTime)
        {
            lastFireTime = Time.time;
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer()
    {
        Vector2 targetPos = player.position;

        Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, targetPos, shootForceTime);

        Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        shootBullet.linearVelocity = projectileVelocity;

        Debug.DrawLine(shootPoint.position, targetPos, Color.red, 1f);
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

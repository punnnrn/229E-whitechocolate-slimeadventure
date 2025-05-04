using UnityEngine;

public class MonsterLookAtPlayer : MonoBehaviour
{
    public Transform player; // ลาก Player เข้ามาใน Inspector

    void Update()
    {
        if (player == null) return;

        Vector3 scale = transform.localScale;

        if (player.position.x > transform.position.x)
        {
            // Player อยู่ทางขวา → หันขวา
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            // Player อยู่ทางซ้าย → หันซ้าย
            scale.x = -Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}

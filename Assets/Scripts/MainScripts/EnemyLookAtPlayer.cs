using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player == null) return;

        Vector3 scale = transform.localScale;

        //หันขวา
        if (player.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        //หันซ้าย
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}

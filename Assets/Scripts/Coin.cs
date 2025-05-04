using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // มูลค่าของเหรียญ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // เรียกใช้ระบบคะแนน
            ScoreManager.Instance.AddScore(coinValue);

            // เล่นเสียง / เอฟเฟกต์ได้ที่นี่ (ถ้าต้องการ)

            Destroy(gameObject); // ทำลายเหรียญ
        }
    }
}
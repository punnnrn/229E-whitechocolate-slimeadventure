using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip collectSound;

    //เช็คการชน
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //เพิ่มจำนวณเหรียญที่เก็บได้
            ScoreManager.Instance.AddScore(coinValue);

            if (collectSound != null)
            {
                //เล่นเสียงตอนเก็บเหรียญ
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
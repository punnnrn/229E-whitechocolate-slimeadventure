using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalFlag : MonoBehaviour
{
    public int requiredCoins = 25;
    public TextMeshProUGUI warningText;

    [Header("Audio")]
    public AudioClip warningSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null && ScoreManager.Instance.currentCoin >= requiredCoins)
            {
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                //ข้อความที่ใชโชว์ และ เล่นเสียง
                ShowWarning("Need " + requiredCoins + " Coin!");
                audioSource.PlayOneShot(warningSound);
               
            }
        }
    }

    //โชว์ขอความเตือน
    void ShowWarning(string message)
    {
        if (warningText != null)
        {
            warningText.text = message;
            CancelInvoke(nameof(HideWarning));
            Invoke(nameof(HideWarning), 2f);
        }
    }

    void HideWarning()
    {
        if (warningText != null)
            warningText.text = "";
    }
}

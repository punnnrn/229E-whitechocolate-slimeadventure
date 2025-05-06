using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentCoin = 0;
    public Text scoreText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentCoin += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Coin : " + currentCoin + " / 25";
    }

    public void ResetScore()
    {
        currentCoin = 0;
        UpdateUI();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [Header("LoseScene")]
    public string gameSceneName = "Map1";
    public string mainMenuSceneName = "MainMenu";

    //เล่นใหม่
    public void Retry()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    //กลับไปหน้าแรก
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

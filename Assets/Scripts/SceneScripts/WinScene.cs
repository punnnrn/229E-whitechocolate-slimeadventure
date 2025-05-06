using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    [Header("LoadScene")]
    public string gameSceneName = "Map1";
    public string mainMenuSceneName = "MainMenu";

    //เล่นใหม่
    public void Retry()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    //กลับไปหน้าหลัก
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

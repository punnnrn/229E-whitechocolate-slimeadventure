using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    [Header("Scene Names")]
    public string gameSceneName = "Map1";
    public string mainMenuSceneName = "MainMenu";

    public void Retry()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

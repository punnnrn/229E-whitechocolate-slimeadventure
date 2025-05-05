using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    //ใช้กลับหน้าหลักจากหน้าเครดิต

    [Header("Scene Settings")]
    public string mainMenuSceneName = "MainMenu";

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // เริ่มเกม
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //หน้าเครดิต
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    // ออกเกม
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has Quit The Game");
    }
}
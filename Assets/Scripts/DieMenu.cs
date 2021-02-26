using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour
{
    public void OnRetry()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
}
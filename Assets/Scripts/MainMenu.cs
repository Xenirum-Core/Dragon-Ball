using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Credits;
    public GameObject Guide;
    public GameObject BestScore;
    public GameObject CurrentScore;

    private void Start()
    {
        GetBestScore();
        GetScore();
    }

    public void OnGuide()
    {
        Main.SetActive(false);
        Guide.SetActive(true);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnCreditsToMain()
    {
        Credits.SetActive(false);
        Main.SetActive(true);
    }

    public void OnCredits()
    {
        Main.SetActive(false);
        Credits.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void GetBestScore()
    {
        BestScore.GetComponent<Text>().text = "Рекорд\n" + "UNIMPL";
    }

    public void GetScore()
    {
        CurrentScore.GetComponent<Text>().text = "Очки\n" + "UNIMPL";
    }
}
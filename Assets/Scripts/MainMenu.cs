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
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("Score") >= PlayerPrefs.GetInt("HighScore"))
                PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        
            BestScore.GetComponent<Text>().text = "Рекорд\n" + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
            BestScore.GetComponent<Text>().text = "Рекорд\n" + PlayerPrefs.GetInt("HighScore");
        }
    }

    public void GetScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            CurrentScore.GetComponent<Text>().text = "Очки\n" + PlayerPrefs.GetInt("Score");
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
            CurrentScore.GetComponent<Text>().text = "Очки\n" + PlayerPrefs.GetInt("Score");
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Dashboard;
    public GameObject Credits;

    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnDashboard()
    {

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
}

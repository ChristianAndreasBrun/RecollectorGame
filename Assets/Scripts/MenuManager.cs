using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //public TextMeshProUGUI timerText;


    private void Start()
    {
        //if (PlayerPrefs.HasKey("TiempoJugado"))
        //{
        //    float timeSaved = PlayerPrefs.GetFloat("TiempoJugado");
        //    TimeSpan time = TimeSpan.FromSeconds(timeSaved);

        //    timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        //}
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void TestLevelGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

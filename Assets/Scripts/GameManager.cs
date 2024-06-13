using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class TimeData
{
    public float tiempoJugado;
}

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image gameOverPanel;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameoverTimerText;

    [Header("BGS & SFX")]
    public AudioSource musicBGS;

    float currentTime;
    bool stopTime;


    private void Update()
    {
        if (!stopTime)
        {
            currentTime += Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        gameoverTimerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
    }


    public IEnumerator cGameOver()
    {
        SaveTimeData();

        yield return new WaitForSeconds(3f);
        gameOverPanel.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        musicBGS.Stop();
        Time.timeScale = 0;
    }

    public void SaveTimeData()
    {
        stopTime = true;

        TimeData timeData = new TimeData();
        timeData.tiempoJugado = currentTime;

        string json = JsonUtility.ToJson(timeData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/tiempo.json", json);
    }
}

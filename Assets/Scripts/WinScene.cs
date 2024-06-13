using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class WinScene : MonoBehaviour
{
    public Image bgPanel1;
    public Image bgPanel2;
    public Image btnsPanel;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI text_1;
    public TextMeshProUGUI text_2;


    void Start()
    {
        LoadTimeData();

        StartCoroutine(cWinScene());
    }

    IEnumerator cWinScene()
    {
        text_1.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        bgPanel1.gameObject.SetActive(false);
        bgPanel2.gameObject.SetActive(true);
        text_2.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        btnsPanel.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        timerText.gameObject.SetActive(true);
    }

    void LoadTimeData()
    {
        string filePath = Application.persistentDataPath + "/tiempo.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TimeData timeData = JsonUtility.FromJson<TimeData>(json);
            float tiempoJugado = timeData.tiempoJugado;

            TimeSpan time = TimeSpan.FromSeconds(tiempoJugado);
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo JSON de tiempo.");
        }
    }
}

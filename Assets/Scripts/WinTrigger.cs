using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    PlayerControl player;
    public GameManager manager;

    public ParticleSystem particle1, particle2;
    public Image winPanel;


    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        particle1.gameObject.SetActive(false);
        particle2.gameObject.SetActive(false);

        player = FindObjectOfType<PlayerControl>();
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        manager.SaveTimeData();
        StartCoroutine(cWinGame());
    }

    IEnumerator cWinGame()
    {
        yield return new WaitForSeconds(0.5f);

        
        player.StopPlayer();


        particle1.gameObject.SetActive(true);
        particle2.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        winPanel.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}

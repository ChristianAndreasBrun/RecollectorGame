using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public Image textPanel;
    public ParticleSystem particle;

    bool particleActive = false;


    private void Start()
    {
        textPanel.gameObject.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textPanel.gameObject.SetActive(false);
            if (particleActive == false)
            {
                StartCoroutine(cParticleSystem());
                particleActive = true;
            }
        }
    }

    IEnumerator cParticleSystem()
    {
        particle.Stop();
        yield return null;
    }
}

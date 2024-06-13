using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeverControl : MonoBehaviour
{
    public TrapControl trap;
    public Animator anim;
    public TextMeshProUGUI interactText;

    [Header("Light Control")]
    public GameObject lt;


    private void Start()
    {
        lt.GetComponent<Light>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            // Desactivar la trampa
            anim.SetBool("isActive", true);
            trap.DisableTrap();

            lt.GetComponent<Light>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(false);

        }
    }
}

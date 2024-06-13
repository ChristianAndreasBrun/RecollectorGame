using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIpanelTrigger : MonoBehaviour
{
    public Image countPanel;


    private void OnTriggerEnter(Collider other)
    {
        countPanel.gameObject.SetActive(true);
    }
}

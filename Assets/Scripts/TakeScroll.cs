using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScroll : MonoBehaviour
{
    public AudioSource takeScroll;

    private void OnTriggerEnter(Collider other)
    {
        takeScroll.Play();
    }
}

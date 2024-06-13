using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNearControl : MonoBehaviour
{
    public Transform openPoint, closePoint;
    public bool isOpen;
    public float openVelocity;


    void Update()
    {
        Transform point = isOpen ? openPoint : closePoint;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, point.rotation, openVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isOpen = false;
        }
    }
}

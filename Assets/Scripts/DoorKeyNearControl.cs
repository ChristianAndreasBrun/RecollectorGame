using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyNearControl : MonoBehaviour
{
    public Transform openPoint, closePoint;
    public bool isOpen;
    public float openVelocity;


    void Update()
    {
        Transform point = (isOpen && transform.childCount == 0) ? openPoint : closePoint;
        transform.position = Vector3.MoveTowards(transform.position, point.position, openVelocity * Time.deltaTime);
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

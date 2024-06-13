using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonControl : MonoBehaviour
{
    public Transform door;
    public Transform openPoint, closePoint;
    public bool isOpen;
    public float openVelocity;
    public float closeDelay;
    

    void Start()
    {
        
    }

    void Update()
    {
        Transform point = isOpen ? openPoint : closePoint;
        door.position = Vector3.MoveTowards(door.position, point.position, openVelocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            CancelInvoke(nameof(CloseDoor));
            isOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Invoke(nameof(CloseDoor), closeDelay);
        }
    }

    void CloseDoor()
    {
        isOpen = false;
    }
}

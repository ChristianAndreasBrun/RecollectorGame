using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorRecollectControl : MonoBehaviour
{
    public Transform openPoint, closePoint;
    public bool isOpen;
    public float openVelocity;
    public TextMeshProUGUI pointUI;
    int initialPoints;
    
    void Start()
    {
        initialPoints = transform.childCount;
    }

    void Update()
    {
        pointUI.text = (initialPoints - transform.childCount) + "/" + initialPoints;
        isOpen = (transform.childCount == 0);
        Transform point = isOpen ? openPoint : closePoint;
        transform.position = Vector3.MoveTowards(transform.position, point.position, openVelocity *  Time.deltaTime);
    }
}

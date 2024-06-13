using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotDoorRecollectControl : MonoBehaviour
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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, point.rotation, openVelocity * Time.deltaTime);
    }
}

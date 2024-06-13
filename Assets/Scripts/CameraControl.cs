using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float distance, height;
    public float speedHeight, speedRotation;
    public float speedWallDetect;

    float currentHeight, finalHeight;
    float currrentRotation, finalRotation;

    RaycastHit hit;
    public LayerMask mask;


    private void LateUpdate()
    {
        if (target == null) return;

        finalHeight = target.position.y + height;
        finalRotation = target.eulerAngles.y;

        currentHeight = transform.parent.position.y;
        currrentRotation = transform.parent.eulerAngles.y;

        currentHeight = Mathf.Lerp(currentHeight, finalHeight, speedHeight * Time.deltaTime);
        currrentRotation = Mathf.LerpAngle(currrentRotation, finalRotation, speedRotation * Time.deltaTime);

        Quaternion rotation = Quaternion.Euler(0, currrentRotation, 0);

        transform.parent.position = target.position;
        transform.parent.position -= rotation * Vector3.forward * distance;

        Vector3 position = transform.position;
        position.y = currentHeight;
        transform.parent.position = position;

        transform.parent.LookAt(target.position);

        if (Physics .Linecast(target.position, transform.parent.position, out hit, mask))
        {
            Vector3 wallPos = hit.point;
            transform.position = Vector3.Lerp(transform.position, wallPos, speedWallDetect * Time.deltaTime);
            transform.LookAt(target.position);
        }
        else
        {
            Vector3 wallPos = Vector3.zero;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, wallPos, speedWallDetect * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

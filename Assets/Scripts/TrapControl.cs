using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    public Transform trap;
    public Transform pos1, pos2;
    public float moveVelocity;

    public int damage;
    public bool isMoving;
    public bool disableTrap;


    private void Update()
    {
        Transform point = isMoving ? pos2 : pos1;
        trap.position = Vector3.MoveTowards(trap.position, point.position, moveVelocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isMoving = true;
            other.GetComponent<PlayerControl>().TakeDamage(damage);
        }
    }

    public void DisableTrap()
    {
        isMoving = false;
        disableTrap = true;
        GetComponent<Collider>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyVisionControl : MonoBehaviour
{
    EnemyControl control;
    Transform player;
    RaycastHit hit;

    public LayerMask mask;


    private void Start()
    {
        control = GetComponentInParent<EnemyControl>();
    }

    private void Update()
    {
        if (player == null) return;
        
        if (Physics.Linecast(transform.parent.position, player.position, out hit, mask))
        {
            if (hit.collider.tag.Equals("Player"))
            {
                control.state = EnemyState.Follow;
            }
            else
            {
                if (control.state == EnemyState.Follow)
                {
                    control.lastPosPlayer = player.position;
                    control.state = EnemyState.Alert;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            player = null;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Tool tool;
    public int timer = 100000;
    public float hitdistance = 5;
    void FixedUpdate()
    {
        if (!Cursor.visible && Input.GetMouseButtonDown(0)){ // if mouse is down
            tool.attackAnimation();
        }
        if (!Cursor.visible && Input.GetMouseButton(0)){ // if mouse is down 
            tool.attackAnimation();
            // if there is a resource in range and the timer is right 
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, hitdistance) && timer > tool.timeBetweenHits)
            {
                hit.transform.GetComponentInParent<Resource>().getDamage(tool);
                timer = 0;
            }
        }
        timer++;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Tool tool;
    public GameObject resourceInRange;
    private int timer = 100000;
    void Update()
    {
        if (!Cursor.visible && Input.GetMouseButtonDown(0)){ // if mouse is down
            tool.attackAnimation();
        }
        if (!Cursor.visible && Input.GetMouseButton(0)){ // if mouse is down 
            tool.attackAnimation();
            // if there is a resource in range and the timer is right 
            if (resourceInRange != null && timer > tool.timeBetweenHits) 
            {
                resourceInRange.GetComponent<Resource>().getDamage(tool.damage);
                Debug.Log(resourceInRange.GetComponent<Resource>());
                 
                timer = 0;
            }

            timer++;
        }
        else
        {
            timer = 100000;
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.GetComponent<Resource>() != null)
            resourceInRange = other.gameObject;
        
        if(other.gameObject.GetComponentInParent<Resource>() != null)
            resourceInRange = other.gameObject.transform.parent.gameObject;
    }
}

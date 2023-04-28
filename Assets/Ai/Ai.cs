using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using Random = System.Random;

public class Ai : MonoBehaviour
{

    public Animator animator;
    public List<string> attackTriggers = new List<string>();
    public List<string> idleTriggers = new List<string>();

    public float range = 0;
    
    public int state = 0; // 0 idle, 1 seek player, 2 attack


    public string getAttack()
    {
        return attackTriggers[new Random().Next(0, attackTriggers.Count)];
    }
    public string getIdle()
    {
        return idleTriggers[new Random().Next(0, idleTriggers.Count)];
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < range)
        {
            state = 2;
        }
        if (state == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position,GameObject.FindWithTag("Player").transform.position, 0.05f);
        }
        else if (state == 2)
        {
            animator.SetTrigger(getAttack());
        }
        
        print("rotatee");
        transform.LookAt(GameObject.FindWithTag("Player").transform.position);
        transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self); 
    }

    public void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < range)
            {
                state = 2;
            }
            else
            {
                state = 1;
            }
        }
    }
}

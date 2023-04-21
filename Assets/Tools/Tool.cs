using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public int damage;
    public int timeBetweenHits = 100;
    public string name;
    public Animator animator;
    
    public void attackAnimation()
    {
        animator.SetTrigger("hit");
    }
    
}

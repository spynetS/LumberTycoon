using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public int damage;
    public int timeBetweenHits = 100;
    public string name;
    public Animator animator;
    public AudioSource hitSound;
    private float timer;
    private float hitTime = 1f;
    
    public void attackAnimation()
    {
        animator.SetTrigger("hit");
        
    }

    private void Update()
    {

    }

}

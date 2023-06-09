using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Tool tool;
    public int timer = 100000;
    public float hitdistance = 5;
    public Transform camera;
    public Resource aimingAt;
    
    [Header("Sound")]
    private AudioSource weaponAudio;
    public float volume;
    public AudioClip hitSound;
    
    void Start() 
    {
        weaponAudio = GetComponent<AudioSource>();
    }
    
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
            Debug.DrawRay(camera.position, camera.TransformDirection(Vector3.forward));
            if (Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, hitdistance) && timer > tool.timeBetweenHits)
            {
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag != "Player")
                {
                    hit.transform.GetComponentInParent<Resource>().getDamage(tool);
                    timer = 0;

                    try
                    {
                        if(!tool.hitSound.isPlaying)
                            tool.hitSound.Play();
                    }catch{}
                    
                    //weaponAudio.PlayOneShot(hitSound, volume);
                }
            }
        }
        timer++;
        RaycastHit hit2;

        if (Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit2, hitdistance))
        {
            Debug.Log(hit2.transform.gameObject.name);
            Resource resource ;//= hit2.transform.gameObject.GetComponent<Resource>();
            if ((resource = hit2.transform.GetComponent<Resource>()) != null || (resource = hit2.transform.GetComponentInParent<Resource>()) != null)
            {
                aimingAt = resource;
            }
        }
        else aimingAt = null;

    }

}

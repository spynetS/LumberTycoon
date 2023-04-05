using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            gameObject.transform.Rotate(new Vector3(10,0,0));
            gameObject.transform.GetComponent<SphereCollider>().enabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.Rotate(new Vector3(-10,0,0));
            gameObject.transform.GetComponent<SphereCollider>().enabled = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.GetComponentInParent<Resource>().health -= 50;
        } catch{}
    }
}

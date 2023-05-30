using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3D : MonoBehaviour
{
    void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        
        transform.LookAt(player);
        transform.Rotate(Vector3.up, 180f);

    }
}


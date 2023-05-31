using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dingdong : MonoBehaviour
{
    public AudioSource dingSound;

    private void OnTriggerEnter(Collider other)
    {
        dingSound.Play();
    }
}

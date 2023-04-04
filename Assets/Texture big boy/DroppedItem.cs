using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    Rigidbody body; 
    void Start(){
        body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(Random.value*2,3,Random.value*2)*50);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            gameObject.SetActive(false);
            try{
                other.gameObject.GetComponent<Player>().inventory.Add(gameObject);
            }catch{

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    Rigidbody body;
    public Sprite inventoryImage;
    public void drop(){
        body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(Random.value*2,5,Random.value*2)*50);
    }

    

}

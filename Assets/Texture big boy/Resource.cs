using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int health = 100;
    public List<GameObject> dropers;
    public void drop(){
        for(int i = 0; i < 10; i++){
            foreach(GameObject item in dropers){
                Instantiate(item, transform.position, transform.rotation);
            }
        }
        Destroy(gameObject);
    }

    void Update(){
        if(health <= 0) drop();
    }

}

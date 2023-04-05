using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int health = 100;
    public int dropMin = 1;
    public int dropMax= 4;
    public List<GameObject> dropers;
    public void drop()
    {
        int amount = (int) Random.Range(dropMin, dropMax);
        for(int i = 0; i < amount; i++){
            foreach(GameObject item in dropers){
                GameObject dropedItem = Instantiate(item, transform.position+new Vector3(0,i,0), transform.rotation);
                dropedItem.GetComponent<DroppedItem>().drop();
            }
        }
        Destroy(gameObject);
    }

    void Update(){
        if(health <= 0) drop();
    }

}

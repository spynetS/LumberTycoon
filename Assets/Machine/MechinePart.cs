using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechine{
    // a part of the mechine
    // the part can transmit the items to another part
    // the part have a max amount, so if the next part is maxed
    // the part should not send to the next part.
    public class MechinePart : MonoBehaviour
    {
        public List<GameObject> items = new List<GameObject>(); //items inside the part
        public int maxRefineItems; // max amount of items
        public MechinePart nextPart; // next part of the mechine
        public int timeBetweenUpdates; // how many times the part should update the part
        private double nextUpdate=1; // keep track for second logic
        private double timer = 0; // second logic

        virtual public void updateMechine(){

        }
        virtual public void UpdateEverySecond(){
            
            if(timeBetweenUpdates > 0 && timer >= timeBetweenUpdates){
                updateMechine();
                timer = 0;
            }
            timer += 1;
        }
        public bool sendItem(int i = 0){
            // if the next part is full dont send the item
            Debug.Log(nextPart.items.Count);
            Debug.Log(nextPart.maxRefineItems);
            if(nextPart.items.Count <= nextPart.maxRefineItems){
                GameObject item = items[i];
                nextPart.getItem(item);
                items.Remove(item);
                return true;
            }
            return false;
        }
        virtual public void getItem(GameObject item){
            items.Add(item);
        }
        // shouldnt exist
        public void Update(){
            // logic to run the update every second every 10th of a secound ;)
            if(Time.time>=nextUpdate){
                // Change the next update (current second+1)
                nextUpdate=(Time.time)+(0.01);
                // Call your fonction
                Debug.Log(nextUpdate);
                UpdateEverySecond();
            }
            var cubeRenderer = transform.gameObject.GetComponent<Renderer>();
            if(items.Count > 0){
                cubeRenderer.material.SetColor("_Color", Color.red);
            }
            else{
                cubeRenderer.material.SetColor("_Color", Color.white);
            }
        }
        
    }

}

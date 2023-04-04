using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mechine{
    public class Refiner : MechinePart
    {
        public TMP_Text mytext;

        public override void updateMechine()
        {
            base.updateMechine();
            string text = "";
            for(int i = 0; i < items.Count; i++){
                items[i].GetComponent<RefineItem>().refined++;
                text += items[i].GetComponent<RefineItem>().refined.ToString()+",";
                if(items[i].GetComponent<RefineItem>().refined > 100){
                    sendItem(i);
                }
            }
            mytext.text = text; 
        }
        // public override void getItem(GameObject item)
        // {
        //     base.getItem(item);
        //     //save the time when we got a item
        //     // we can then check of the time is done and we can send that item
        //     itemsTimer.Add(Time.time);
        // }
    }
}

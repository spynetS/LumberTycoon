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
            try
            {
                for(int i = 0; i < items.Count; i++)
                {
                    RefineItem item = items[i].GetComponent<RefineItem>();
                    item.refined++;
                    text += item.refined.ToString()+",";
                    
                    if(item.refined > 100){
                        sendItem(i, item.getRefined());
                    }
                }
            }
            catch {}
            
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

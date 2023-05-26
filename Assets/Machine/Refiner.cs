using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mechine{
    public class Refiner : MechinePart
    {
        public TMP_Text mytext;
        
        private AudioSource machineAudio;
        private float volume;
        public audioClip factory;
        
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
                    
                    machineAudio.PlayOneShot(factory, volume);
                    
                    if(item.refined > 100)
                    {
                        GameObject newItem = Instantiate(item.getRefined());
                        newItem.SetActive(false);
                        Destroy(item.gameObject);
                        
                        sendItem(i, newItem);
                    }
                }
            }
            catch {}
            
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Mechine{
    public class Refiner : MechinePart
    {
        public TMP_Text mytext;
        
        [Header("Sound")]
        private AudioSource machineAudio;
        public float volume;
        public AudioClip factory;
        
        public override void updateMechine()
        {
            base.updateMechine();
            string text = "";
            
                for (int i = 0; i < items.Count; i++)
                {
                    RefineItem item = items[i].GetComponent<RefineItem>();
                    item.refined++;
                    text += item.refined.ToString() + ",";

                    try
                    {
                        machineAudio.PlayOneShot(factory, volume);
                    }catch{}

                    if (item.refined > 100)
                    {
                        GameObject newItem = Instantiate(item.getRefined());
                        newItem.SetActive(false);
                        Destroy(item.gameObject);

                        sendItem(i, newItem);
                    }
                }
            
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

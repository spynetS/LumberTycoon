using System;
using TMPro;
using UnityEngine;

namespace Mechine
{
    public class Machine : MonoBehaviour
    {
        public Input   input;
        public Refiner refiner;
        public Output  output;

        public GameObject tube;
        
        public GameObject particle0;
        public GameObject particle1;
        
        public GameObject round0;
        public GameObject round1;
        public GameObject round2;

        public int round = 0;
        public int particle = 0;

        public TMP_Text inputText;
        public TMP_Text refineText;
        public TMP_Text outText;

        private RefineItem getMostRefined()
        {
            RefineItem max = null;
            foreach (GameObject i in refiner.items)
            { 
                RefineItem item;
                if((item = i.GetComponent<RefineItem>()) != null)
                {
                   if (max == null)
                   {
                       max = item;
                   }
                   else
                   {
                       if (max.refined < item.refined)
                       {
                           max = item;
                       }
                   }
                   
                }
            }

            return max;
        }
        
        private void Update()
        {
            inputText.text = input.items.Count + " / " + input.maxRefineItems + " st";
            outText.text = output.items.Count + " / " + output.maxRefineItems + " st";
            try
            {
                refineText.text = getMostRefined().refined + "%\n" +
                                  refiner.items.Count + " / " + refiner.maxRefineItems + " st";
            }
            catch
            {
                refineText.text = "0%\n" +
                                  refiner.items.Count + " / " + refiner.maxRefineItems + " st";
            }
        }

        public void turnOnRoundThing()
        {
            if (round == 0)
                round0.SetActive(true);
            else if(round == 1)
                round1.SetActive(true);
            else
                round2.SetActive(true);
            round++;
        }

        public void turnOnTube()
        {
           tube.SetActive(true); 
        }

        public void turnParticles()
        {
            if (particle == 0)
                particle0.SetActive(true);
            else if(particle == 1)
                particle1.SetActive(true);
            
            particle++;
        }

    }
}
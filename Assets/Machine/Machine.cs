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
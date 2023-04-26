using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechine{
    public class RefineItem : MonoBehaviour
    {
        public int refined;                   // how much is refined
        
        [Header("refinedItems are the items that can be outputed after a item is refined")]
        public List<GameObject> refinedItems; // bi products
        
        [Header("to choose the chance of the item to be refined to use refinedChance")]
        [Header("and add the percentage of the drop")]
        public List<int> refinedChance;       // bi products


        public GameObject getRefined()
        {
            // add add the amount of ids based on the refineChance value
            // we loop though the refinedChance list and add the amount of 
            // gameobject ids to the gameObvjectsId list
            // then we get a random id from the list which corresponds with
            // a gameobject int he refinedItems list and return that obejct.
            List<int> gameObjectsId = new List<int>();
            for (int chance = 0; chance < refinedChance.Count; chance++)
            {
                for (int i = 0; i < refinedChance[chance]; i++)
                {
                   gameObjectsId.Add(chance); 
                }
            }

            int index = Random.Range(1, (gameObjectsId.Count - 1));
            
            return refinedItems[gameObjectsId[index]];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechine{
    public class Output : MechinePart
    {
        public override void getItem(GameObject item)
        {
            base.getItem(item);
            
            item.transform.position = transform.position + (transform.up * -3);
            item.SetActive(true);
            item.GetComponent<DroppedItem>().drop();
            
        }
    }
}

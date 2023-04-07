using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mechine{

    public class Input : MechinePart
    {
        public override void updateMechine()
        {
            if(items.Count > 0)
                sendItem();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Mechine;
using TMPro;
using UnityEngine;
using Object = System.Object;

public class ItemHolderButton : MonoBehaviour
{
    public TMP_Text text;

    public string before;

    public int amount;

    public int part; //0 input , 1 refine
    
    void Update()
    {
        Machine m = GameObject.FindWithTag("Machine").GetComponent<Machine>();
        MechinePart part = this.part == 0 ? m.input : m.refiner;
        print(this.part);
        text.text = before+" "+(amount + 10 * part.maxRefineItems).ToString();
    }
}

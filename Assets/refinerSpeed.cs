using System.Collections;
using System.Collections.Generic;
using Mechine;
using TMPro;
using UnityEngine;
using Object = System.Object;

public class refinerSpeed : MonoBehaviour
{
    public TMP_Text text;
    public string before;
    public int amount;
    void Update()
    {
        Machine machine = GameObject.FindWithTag("Machine").GetComponent<Machine>();

        text.text = before+" "+(amount + 10 * (100 - machine.refiner.timeBetweenUpdates)).ToString();
    }
}

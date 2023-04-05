using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TMP_Text mytext;
    public List<GameObject> inventory = new List<GameObject>();


    private void Update()
    {
        mytext.text = inventory.Count.ToString();
    }
}

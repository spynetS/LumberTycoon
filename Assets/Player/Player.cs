using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mechine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public TMP_Text mytext;
    public List<GameObject> inventory = new List<GameObject>();

    private void Update()
    {
        mytext.text = inventory.Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            other.GetComponent<Mechine.Input>().getItem(inventory[0]);
            inventory.Remove(inventory[0]);
        } catch{}
    }
}

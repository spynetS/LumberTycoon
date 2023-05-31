using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class AimData : MonoBehaviour
{

    public TMP_Text name;
    public TMP_Text health;
    public TMP_Text drop;
    public Attack attack;
    public Image crosshair;

    private void Start()
    {
        attack = GameObject.FindWithTag("Player").GetComponentInChildren<Attack>();
    }

    private void Update()
    {
        Resource resource = attack.aimingAt;
        if (resource != null)
        {
            name.text = "Name: " + resource.resourceName;
            health.text = "Health: " + resource.health.ToString();
            string d = "Dropping: ";
            foreach (GameObject a in resource.dropers)
            {
                d += a.GetComponent<DroppedItem>().name;
            }

            drop.text = d;
            crosshair.color = Color.red;
        }
        else
        {
            name.text = "Name: ";
            health.text = "Heath: ";
            drop.text = "Dropping: ";
            crosshair.color = Color.white;
        }
    }
}

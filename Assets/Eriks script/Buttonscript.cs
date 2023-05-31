using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonscript : MonoBehaviour
{

    public GameObject panel;
    
    public void turnOn()
    {
        panel.SetActive(true);
    }

    public void turnOff()
    {
        panel.SetActive(false);
    }
    
}

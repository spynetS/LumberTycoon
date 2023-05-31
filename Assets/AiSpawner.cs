using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AiSpawner : MonoBehaviour
{

    public int amount = 1;
    public GameObject prefab;
    
    public List<GameObject> ais;
    public Vector2 area = new Vector2(10,10);

    private void Update()
    {
        foreach (GameObject g in ais)
        {
            if (g == null) ais.Remove(g);
        }
        if (ais.Count < amount)
        { 
            GameObject g = Instantiate(prefab, transform);
            g.transform.position += new Vector3(Random.Range(-area.x,area.x), 0f, Random.Range(-area.y,area.y));
            ais.Add(g);
            
        }
    }
}

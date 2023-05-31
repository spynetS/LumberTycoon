using System;
using System.Collections;
using System.Collections.Generic;
using Mechine;
using UnityEngine;
using Player;
using Unity.VisualScripting;
using Input = UnityEngine.Input;

public class ShopUpgrade : MonoBehaviour
{
    public Player.Player player;
    public Mechine.Machine machine;
    public Canvas canvas;
    public List<GameObject> tools;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player.Player>();
        machine = GameObject.FindWithTag("Machine").GetComponent<Mechine.Machine>();
    }

    public void buyTool(string value)
    {
        int index = int.Parse(value.Split(";")[0]);
        float amount = float.Parse(value.Split(";")[1]);

        if (buy(amount))
        {
            player.addTool(tools[index]);
        }
        
    }
    

    public void turnOnCanvas()
    {
        canvas.enabled = !canvas.enabled;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && player.shop)
        {
            turnOnCanvas();     
        }
        if(!player.shop && canvas.enabled) turnOnCanvas();
    }

    public void upgradeSpeed(int amount)
    {
        if (buy(amount))
        {
            player.playerMovement.runSpeed += 2;
            player.playerMovement.walkSpeed += 1;
        }
    }

    public void upgradeInventory(float amount)
    {
        if (player.inventory.stackSize < 12)
        {
            if (buy(amount)) {
                player.inventory.stackSize += 1;
            }
        }
        else
        {
            if (buy(amount)) {
                player.inventory.stackSize = 12;
            }
        }
    }

    public void upgradeMachineSpeed(float amount)
    {
        if (machine.refiner.GetComponent<Refiner>().timeBetweenUpdates > 5)
        {
            if (buy(amount)) {
                machine.refiner.GetComponent<Refiner>().timeBetweenUpdates -= 5;
                machine.turnOnTube();
            }
        }
        else
        {
            if (buy(amount)) {
                machine.refiner.GetComponent<Refiner>().timeBetweenUpdates = 1;
                machine.turnOnTube();
            }
        }
    }
    // "1;100"  first part secound money
    public void upgradeMachineHolder(string value)
    {
        int index = int.Parse(value.Split(";")[0]);
        float amount = float.Parse(value.Split(";")[1]);
        if (buy(amount))
        {
            switch (index)
            {
               case 0:
                   upgradeMachineHolder(machine.input, amount);
                   break;
               case 1:
                   upgradeMachineHolder(machine.refiner, amount);
                   break;
               case 2:
                   upgradeMachineHolder(machine.output, amount);
                   break;
            }
        }
    }
    public void upgradeMachineHolder(MechinePart part, float amount)
    {
        if (buy(amount))
        {
            part.maxRefineItems++;
            machine.turnOnRoundThing();
        }
    }
    
    private bool buy(float amount)
    {
        if (player.money - amount >= 0)
        {
            player.money -= amount;
            return true;
        }

        return false;
    }

    
    
}

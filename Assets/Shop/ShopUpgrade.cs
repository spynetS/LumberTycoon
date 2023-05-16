using System;
using System.Collections;
using System.Collections.Generic;
using Mechine;
using UnityEngine;
using Player;
using Unity.VisualScripting;

public class ShopUpgrade : MonoBehaviour
{
    Player.Player player;
    public Mechine.Machine machine;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player.Player>();
        machine = GameObject.FindWithTag("Machine").GetComponent<Mechine.Machine>();
        upgradeInventory();
    }

    /*
     * Machine{
     * refineSpeed;
     * refineAmount;
     * 
     *}
     * Player {
     * runSpeed;
     * inventory moreSlots;
     * }
     *
     * 
     * 
     */
    

    public void upgradeSpeed()
    {
        player.playerMovement.moveSpeed += 2;
    }

    public void upgradeInventory()
    {
        player.inventory.stackSize += 5;
    }

    public void upgradeMachineSpeed()
    {
        machine.refiner.GetComponent<Refiner>().timeBetweenUpdates -= 5;

    }

}

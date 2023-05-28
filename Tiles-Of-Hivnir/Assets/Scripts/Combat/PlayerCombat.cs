using System;
using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using TalesofHivnir.Entities;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int playerhealth;
    public int playercurrenthealth;

    public bool isDead;

    public Healthbar healthbar;

    public ProgrammingBlockInterpreter gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerhealth = Player.Health;
        playerhealth = Player.instance.maxhealth;
        Debug.Log(Player.instance.maxhealth);
        healthbar.SetMaxHealth(playerhealth);
    }

    public void GotDamage()
    {
        healthbar.SetHealth(Player.instance.currenthealth);
        //healthbar.SetHealth(playercurrenthealth);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("dans la zone");
        Player.instance.currenthealth = 0;
        //playercurrenthealth = 0;
        healthbar.SetHealth(Player.instance.currenthealth);
        //healthbar.SetHealth(playercurrenthealth);
        Player.instance.currenthealth = Player.instance.maxhealth;
        gameManager.gameOver();
    }

    // Update is called once per frame
}

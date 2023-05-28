using System;
using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using TalesofHivnir.Entities;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    //public int playerhealth;
    //public int playercurrenthealth;

    public bool isDead;

    public Healthbar healthbar;

    public ProgrammingBlockInterpreter gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(SaveData.instance.maxhealth);
        healthbar.SetHealth(SaveData.instance.currenthealth);
        //healthbar.SetMaxHealth(SaveData.instance.maxhealth);
    }

    public void GotDamage()
    {
        healthbar.SetHealth(SaveData.instance.currenthealth);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        SaveData.instance.currenthealth = 0;
        healthbar.SetHealth(SaveData.instance.currenthealth);
        SaveData.instance.currenthealth = SaveData.instance.maxhealth;
        gameManager.gameOver();
    }

    // Update is called once per frame
}

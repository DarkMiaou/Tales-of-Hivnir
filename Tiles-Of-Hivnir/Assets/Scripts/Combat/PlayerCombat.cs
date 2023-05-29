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
        SetEnemy();
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
        if (col.gameObject.name != "LogMonster")
        {
            SaveData.instance.currenthealth = 0;
            healthbar.SetHealth(SaveData.instance.currenthealth);
            SaveData.instance.currenthealth = SaveData.instance.maxhealth;
            gameManager.gameOver();
        }
    }

    public void SetEnemy()
    {
        switch (gameObject.scene.name)
        {
            case "COMBATMODE":
                SaveData.instance.monstermaxhealth = 100;
                SaveData.instance.monstercurrenthealth = 100;
                SaveData.instance.monsterdamage = 20;
                ;
                break;
        }
    }

    // Update is called once per frame
}

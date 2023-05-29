using System;
using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Healthbar healthbar;

    private int maxhealth;
    public int damage;
    public float currenthealth;
    private Transform player_;
    private Transform mob_;
    private float x;
    private float y;

    public bool isinside = false;
    public bool blockcalled = false;

    public void TakeDamage()
    {
        /*x = mob_.position.x - player_.position.x;
        y = mob_.position.y - player_.position.y;
        if (Math.Abs(x)>= 0 && Math.Abs(x) <= 1 && Math.Abs(y)>= 0 && Math.Abs(y) <= 1 )
        {
            currenthealth -= damage;
            healthbar.SetHealth(currenthealth);
        }
        else
        {
            healthbar.SetHealth(currenthealth);
        }*/

        if (isinside == true && blockcalled == true)
        {
            currenthealth -= SaveData.instance.damage;
            healthbar.SetHealth(currenthealth);
            isinside = false;
            blockcalled = false;
            Debug.Log("Attaque réalisé");
        }
        Debug.Log("isinside = " + isinside);
        Debug.Log("blockcalled = " + blockcalled);

    }
    
    private void Start()
    {

        switch (gameObject.name)
        {
            case "LogMonster":
                maxhealth = 50;
                currenthealth = 50;
                damage = 20;
                healthbar.SetMaxHealth(maxhealth);
                healthbar.SetHealth(currenthealth);
                Debug.Log("setvie");
                break;
        }

        isinside = false;
        blockcalled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player 1")
        {
            isinside = true;
            Debug.Log("detect");
            
        }
        Debug.Log("zzzz");
    }
}

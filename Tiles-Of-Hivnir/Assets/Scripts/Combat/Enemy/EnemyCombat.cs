using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public static EnemyCombat instance;
    
    public Healthbar healthbar;

    public int maxhealth;
    public int damage;
    public int currenthealth;

    

    /*ublic int damage
    {
        get { return _damage;}
        set
        { switch (gameObject.name)
            {
                case "LogMonster" :
                    _damage = 20;
                    break;
            }
        }
    }*/

    /*public int maxhealth
    {
        get { return maxhealth;}
        set
        {
            switch (gameObject.name)
            {
                case "LogMonster" :
                    maxhealth = 50;
                    break;
            }
            
        }
    }*/
    
    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthbar.SetHealth(currenthealth);

    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Debug.Log("zzzz");
        /*maxhealth = 50;
        currenthealth = maxhealth;
        damage = 20;
        healthbar.SetMaxHealth(maxhealth);*/

    }

    public void SetMax()
    {
        healthbar.SetMaxHealth(maxhealth);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using TalesofHivnir.Entities;
using UnityEngine;

public class LogMonster : MonoBehaviour
{
    public static int LifeLog = 100;
    public Healthbar healthbar;

    private void Start()
    {
       LifeLog = 100;
       healthbar.SetMaxHealth(LifeLog);
    }

    /*public  void Attack()
    {
        //LifeLog =(int)(Player.strenght * Player.bonusattack);
        LifeLog =(int)(Player.instance.strenght * Player.instance.BonusStrenght);
        healthbar.SetHealth(LifeLog);
    }*/
    public bool isAlive()
    {
        if (LifeLog <= 0)
            return false;
        else 
            return true;
        
    }

    public bool Win()
    {
        if (isAlive() == false)
            return true;
        else
            return false;
    }
    
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}

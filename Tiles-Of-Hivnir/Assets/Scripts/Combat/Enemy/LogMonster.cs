using System.Collections;
using System.Collections.Generic;
using TalesofHivnir.Entities;
using UnityEngine;

public class LogMonster : MonoBehaviour
{
    public static int LifeLog = 100;

    public static void Attack()
    {
        LifeLog =- 50;
    }
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

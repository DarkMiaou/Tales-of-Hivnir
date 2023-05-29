using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    //Player
    public int currenthealth = 100;
    public int maxhealth = 100;
    public int damage = 20;
    
    //Monster
    /*public int monstermaxhealth;
    public int monstercurrenthealth;
    public int monsterdamage;*/


    void Start()
    {
        currenthealth = 100; 
        maxhealth = 100;
        damage = 20;
    }
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /*if (gameObject.scene.name == "COMBATMODE")
        {
            switch (gameObject.name)
            {
                case "LogMonster":
                    monstermaxhealth = 100;
                    monstercurrenthealth = 100;
                    monsterdamage = 20; ;
                    break;
            }
        }*/
    }

    // Update is called once per frame
}

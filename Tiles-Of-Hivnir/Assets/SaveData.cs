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
    public int monstermaxhealth = 0;
    public int monstercurrenthealth = 0;
    public int monsterdamage = 0;


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
    }

    // Update is called once per frame
}

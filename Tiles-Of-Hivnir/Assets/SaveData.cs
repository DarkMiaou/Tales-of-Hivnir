using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TalesofHivnir.Items;
using UnityEditor;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    //Player
    public double x;
    public double y;
    public float currenthealth = 100;
    public float maxhealth = 100;
    public float damage = 20;
    public List<Item> Newinv;
    public float bonusdefence;
    public int strenght;
    public float bonusattack;
    public float bonusspeed;
    public bool ClasseEspeceChoisie;
    
    //Monster
    public int monstermaxhealth = 0;
    public int monstercurrenthealth = 0;
    public int monsterdamage = 0;

    
    void Start()
    {
        x = -19.1;
        y = -4.36;
        Newinv = new List<Item>() {};
        bonusdefence= 1.2f;
        strenght = 20;
        bonusattack=1.2f;
        currenthealth = 100; 
        maxhealth = 100;
        damage = 20;
        bonusspeed = 5f;
        ClasseEspeceChoisie = false;
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

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
    public int currenthealth = 100;
    public int maxhealth = 100;
    public int damage = 20;
    
    //Monster
    public int monstermaxhealth = 0;
    public int monstercurrenthealth = 0;
    public int monsterdamage = 0;

    public List<Item> Newinv;
    public int Newmaxhealth;
    public float Newbonusdefence;
    public int Newstrenght;
    public float Newbonusattack;
    public float Newbonusspeed;
    public bool ClasseEspeceChoisie;
    void Start()
    {
        x = -19.1;
        y = -4.36;
        Newinv = new List<Item>() {};
        Newmaxhealth = 100;
        Newbonusdefence= 1.2f;
        Newstrenght = 20;
        Newbonusattack=1.2f;
        currenthealth = 100; 
        maxhealth = 100;
        damage = 20;
        Newbonusspeed = 5f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    public int currenthealth = 100;
    public int maxhealth = 100;


    void Start()
    {
        currenthealth = 100; 
        maxhealth = 100;
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

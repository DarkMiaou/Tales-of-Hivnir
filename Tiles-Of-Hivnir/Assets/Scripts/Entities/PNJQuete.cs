using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TalesofHivnir;
using TalesofHivnir.Entities;
using TalesofHivnir.Items;
using TalesofHivnir.Menus;
using UnityEngine;

public class PNJQuete : MonoBehaviour
{
    public Item quest_item;
    public int number_of_item;
    public Item reward;
   
    public Transform npc;
    public Transform player;
    private float posx;
    private float posy;
    
    public Inventory inv;
    public int range;

    private void Start()
    {
        
    }

    void Update()
    {
        posx = Math.Abs(npc.position.x - player.position.x);
        posy = Math.Abs(npc.position.x - player.position.y);
        foreach (var ele in inv.InvList)
        {
            if (ele.Name == quest_item.Name)
            {
                inv.InvList.Remove(quest_item);
                if (quest_item is Weapon)
                {
                    SaveData.instance.damage -= quest_item.Level;
                }
                else
                {
                    SaveData.instance.maxhealth =- quest_item.Level;
                    SaveData.instance.currenthealth =- quest_item.Level;
                }
                inv.InvList.Add(reward);
                if (reward is Weapon)
                {
                    SaveData.instance.damage += reward.Level;
                    
                }
                else if (reward is Potion)
                {
                    SaveData.instance.maxhealth =+ reward.Level;
                    SaveData.instance.currenthealth =+ reward.Level;
                }
                inv.ActualiseDisplay();
                Debug.Log("ca marche");
            }


        }
        
       
    }
}

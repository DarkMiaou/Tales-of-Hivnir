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
                inv.InvList.Add(reward);
                if (reward is Weapon)
                {
                    SaveData.instance.bonusattack =+ reward.Level * 0.1f;
                    
                }
                else if (reward is Potion)
                {
                    SaveData.instance.bonusdefence =+ reward.Level * 0.1f;
                }
                inv.ActualiseDisplay();
                Debug.Log("ca marche");
            }


        }
        
       
    }
}

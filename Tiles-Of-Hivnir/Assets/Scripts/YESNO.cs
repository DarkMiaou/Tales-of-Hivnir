using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Realtime;
using TalesofHivnir;
using TalesofHivnir.Items;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Player = TalesofHivnir.Entities.Player;
using Random = System.Random;

public class YESNO : MonoBehaviour
{
    private Random lootrd;
  
    public List<Item> loot1;
    private Item reward;
    public List<int> chance;
    public Image icone;
    public TMP_Text text;
    public Inventory inv;
    


    public void Start()
    {
     
        lootrd = new Random();
        reward = Loot();
        icone.sprite = reward.Icone;
        text.text = reward.Name;
    }

    public Item Loot()
    {
        Item res = null;
        int n = lootrd.Next(0, 100);
        int l = loot1.Count;
        int i = 0;
        while (i < l)
        {
            
            if (n < chance[i])
            {
               res= loot1[i];
            }

            i++;

        }

        return res;
    }

    public void Yes()
    {
       
        if (inv.InvList.Count > 9)
        {
            inv.InvList.Remove(inv.InvList[0]);
            inv.InvList.Add(reward);
            inv.ActualiseDisplay();
        }
        else
        {
            inv.InvList.Add(reward);
            inv.ActualiseDisplay();
        }
        SceneManager.LoadScene("Map");
       
      
      
        

    }

    public void No()
    {
        SceneManager.LoadScene("Map");
    }
}

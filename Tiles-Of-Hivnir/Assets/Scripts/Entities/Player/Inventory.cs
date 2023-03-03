using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TalesofHivnir.Items;
using TalesofHivnir.Menus;
using UnityEngine.UI;
namespace TalesofHivnir
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> InvList;
        public List<Image> InvDisplayList;
        public InvMenu InvMenuObj;
        
        

        public void AddItem(Item item,ChestController chest)
        {
            if (item == null)
            {
                Debug.Log("Failed to Add : Chest is Empty");
                InvMenuObj.ItemNullDiplay();
            }
            else
            {
                if (InvList.Count >= 10)
                {
                    if (!InvMenuObj.InvFullDisplay(this,item))
                    {
                        if (!chest.IsInfiny)
                        {
                            chest.Content = null;
                        }
                    }
                }
                else
                {
                    Debug.Log("Avant le Add");
                    InvList.Add(item);
                    if (!chest.IsInfiny)
                    {
                        chest.Content = null;
                    }
                    ActualiseDisplay();
                    
                }
            }
            
        }

        public void AddInvPlein(Item item)
        {
            Debug.Log("Failed to Add : Inv is Full");
        }

        public void ActualiseDisplay() //à faire
        {
            int cpt = 0;
            int l = InvList.Count;   
            foreach (var elt in InvList)
            {
                InvDisplayList[cpt].color= Color.white;
                InvDisplayList[cpt].sprite = elt.Icone;
                cpt++;
            }

            while (cpt < 10)
            {
                InvDisplayList[cpt].sprite=null;
                InvDisplayList[cpt].color = Color.clear;
                cpt++;
            }
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}


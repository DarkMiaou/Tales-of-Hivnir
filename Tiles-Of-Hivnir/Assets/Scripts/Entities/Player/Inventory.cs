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

        private void Start()
        {
            ActualiseDisplay();
        }

        public void AddItem(Item item, ChestController chest)
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
                    if (!InvMenuObj.InvFullDisplay(this, item))
                    {
                        if (!chest.IsInfiny)
                        {
                            chest.Content = null;
                        }
                    }
                }
                else
                {
                    if (!InvMenuObj.InvNotFullDisplay(this, item))
                    {
                        if (!chest.IsInfiny)
                        {
                            chest.Content = null;
                        }
                    }
                }
                
            }
        }

        public void AddInvPlein(Item item)
        {
            Debug.Log("Failed to Add : Inv is Full");
        }

        public void ActualiseDisplay() // à appeler à chaques modifs de l'inventaire
        {
            int cpt = 0;
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


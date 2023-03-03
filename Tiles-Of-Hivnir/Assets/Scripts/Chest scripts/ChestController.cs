using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TalesofHivnir;
using TalesofHivnir.interactable;
using TalesofHivnir.Items;


namespace TalesofHivnir
{
    public class ChestController : MonoBehaviour
    {
        public bool isOpen;
        public Item Content;
        public Inventory InvToFill;
        public bool IsInfiny; //si il ets sur true on va pouvoir prendre le même item à l'infini
    
        public void OpenChest()
        {
            if (!isOpen)
            {
                InvToFill.AddItem(Content);
                if (!IsInfiny)
                {
                    Content = null;
                }
                isOpen = true;
                Debug.Log("Chest is open");
            }
        }
        
        public void CloseChest()
        {
            if (isOpen)
            {
                isOpen = false;
                Debug.Log("chest closed");
            }
        }

    }
}






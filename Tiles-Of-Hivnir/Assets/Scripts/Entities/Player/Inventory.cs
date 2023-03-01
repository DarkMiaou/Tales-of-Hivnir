using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TalesofHivnir.Items;


namespace TalesofHivnir
{
    public class Inventory : MonoBehaviour
    {
        public List<Item> InvList;
    
    
        // Start is called before the first frame update
        void Start()
        {
        }

        public void AddItem(Item item)
        {
            if (item != null)
            {
                if (InvList.Count == 10)
                {
                    AddInvPlein(item);
                
                }
                else
                {
                    Debug.Log("Avant le Add");
                    InvList.Add(item); //GameObject.FindGameObjectWithTag("inv"+InvList.Count.ToString())))
                }
            }
            
        }

        public void AddInvPlein(Item item)
        {
            Debug.Log("Failed to Add : Inv is Full");
        }

        public void Display() //à faire
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}


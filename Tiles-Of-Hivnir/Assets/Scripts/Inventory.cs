using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TalesofHivnir.Items;

namespace TalesofHivnir
{
    public class Inventory : MonoBehaviour
    {
        public Item[] InvList;
    
    
        // Start is called before the first frame update
        void Start()
        {
        }

        public void AddItem(Item item)
        {
            if (InvList.Length == 10)
            {
                AddInvPlein(item);
            }
            else
            {
                InvList.Append(item);
            }
        }

        public void AddInvPlein(Item item)
        {
            throw new NotImplementedException();
        }

        public void Display()
        {
            int cpt = 0;
            foreach (var VARIABLE in InvList)
            {
                throw new NotImplementedException();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}


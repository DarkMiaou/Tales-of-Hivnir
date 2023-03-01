using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir.Items
{
    public class DisplayableItem : MonoBehaviour
    {
        public Item Item_toDisplay;
        public GameObject Casedelinv;

        public DisplayableItem(Item item, GameObject casedelinv)
        {
            Item_toDisplay = item;
            Casedelinv = casedelinv;
        }
        
        
    }
        

}
// Work in progress
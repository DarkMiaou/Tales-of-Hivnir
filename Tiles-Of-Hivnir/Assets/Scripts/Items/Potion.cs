using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir.Items
{
    public class Potion : Item
    {
        public Potion(string name, Sprite ico,int lvl) : base(name,ico,lvl)
        {
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }

}

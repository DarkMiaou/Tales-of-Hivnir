using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir.Items
{
    public abstract class Item : MonoBehaviour
    {
        public string Name;
        public Sprite Icone; //Icone dans la barre d'inventaire
        public int Level;

        public Item(string name, Sprite ico,int lvl)
        {
            Name = name;
            Icone = ico;
            Level = lvl;
        }
        public abstract void Use();

    }
}


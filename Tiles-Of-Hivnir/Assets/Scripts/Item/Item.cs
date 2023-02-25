using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
   public string Name;
   public Sprite Icone; //Icone dans la barre d'inventaire

   public abstract void Use();

}

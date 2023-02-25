using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Weapon(string name, Sprite ico)
    {
        Name = name;
        Icone = ico;

    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}

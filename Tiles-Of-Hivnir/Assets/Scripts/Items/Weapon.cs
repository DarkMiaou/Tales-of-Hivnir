using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir.Items
{

    public class Weapon : Item
    {
        public string Favorite_race;
        public int Bonus;

        public Weapon(string favorite, int bonus,string name, Sprite icone,int lvl) : base(name,icone,lvl)    
        {
            Bonus = bonus;
            Favorite_race = favorite;
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }

        public int New_Damage(string race)
        {
            int res = Bonus;
            if (Favorite_race == race)
            {
                res *= 2;
            }

            return res;
        }
    }
}

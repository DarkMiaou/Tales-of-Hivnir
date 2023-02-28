using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using TalesofHivnir.Items;
using UnityEngine;

namespace TalesofHivnir
{
    public class Player : Entity
    {
        public int Maxlife = 100;
        //Pour l'iventaire voir le fichier inventaire de Killian
        public void TakeDamage()
        {
        }

        public void AddExp(Item n)
        {
            //Level = Level + le nombre d'exp de l'item en question
        }

        public void AddLife(Item n)
        {
            /*if (Health < Maxlife)
                Health = Health + lr nombre de vie de l'objet utilisé*/
        }

        public bool AliveCheck()
        {
            if (Health > 0)
                return true;
            else
                return false;
        }

    }
}

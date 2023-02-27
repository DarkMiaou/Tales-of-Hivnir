using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void Awake()
        {
            instance = this;
        }

        // Ressource sous forme de liste
        public List<Sprite> WeaponSprites;
        public List<Sprite> PotionSprites;
        public List<Sprite> CardSprites;
        public List<int> WeaponPrices;
        public List<int> XpTable;

        // References
        public PlayerController player;
        // public weapons etc pour chaque arme;

        // Logic
        public int Money;
        public int Experience;
        public int Damage;

        public void SaveState()
        {

        }

        public void LoadState()
        {

        }

    }
}

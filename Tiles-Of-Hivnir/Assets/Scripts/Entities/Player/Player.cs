using System.Collections;
using System.Collections.Generic;
using Entities.Player;
using TalesofHivnir;
using TalesofHivnir.Items;
using UnityEngine;

namespace TalesofHivnir.Entities
{
    public class Player : Entity
    {
        public PlayerController playercont;
        
        // Bonus de la Classe
        private Classe _ChosenClasse;
        public Classe ChosenClasse
        {
            get { return _ChosenClasse; }
            set {
                _ChosenClasse = value;
                switch (_ChosenClasse)
                {
                    case Classe.Barbare: BonusAttack = true;
                        break;
                    case Classe.Berserker: BonusArmor = true;
                        break;
                    case Classe.Sorcier: Wizard = true;
                        break;
                }
            }
        }
        public bool Wizard;     //Sorcier
        public bool BonusAttack;    //Barbare
        public bool BonusArmor;    //Berserker
        
        // Bonus de l'Espece
        // Chaque int va avoir 0 -1 ou 1,
        // si on a 1 c'est qu'il y a un bonus à appliquer
        // si on a -1 c'est qu'on a un malus à appliquer 
        private Espece _ChosenEspece;
        private int _BonusSpeed;
        public Espece ChosenEspece{
            get { return _ChosenEspece; }
            set {
                _ChosenEspece = value;
                switch (_ChosenEspece)
                {
                    case Espece.Orc:
                        BonusStrenght = 1;
                        BonusSpeed = -1;
                        break;
                    case Espece.Géant:
                        BonusLife = 1;
                        BonusSpeed = -1;
                        break;
                    case Espece.Humain:
                        BonusStrenght = 1;
                        BonusLife = -1;
                        break;
                    case Espece.Nain:
                        BonusSpeed = 1;
                        BonusLife = -1;
                        break;
                    case Espece.Elfe:
                        BonusStrenght = -1;
                        BonusLife = 1;
                        break;
                    case Espece.Fée:
                        BonusStrenght = -1;
                        BonusSpeed = 1;
                        break;
                }
            }
        }
        public int BonusStrenght;

        public int BonusSpeed
        {
            get { return _BonusSpeed;}
            set
            {
                _BonusSpeed = value;
                if (_BonusSpeed == 1)
                {
                    playercont.speed = playercont.basespeed + 1f;
                }
                else if (_BonusSpeed == -1)
                {
                    playercont.speed = playercont.basespeed - 1f;
                }
            }
        }
        public int BonusLife;
        
        
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

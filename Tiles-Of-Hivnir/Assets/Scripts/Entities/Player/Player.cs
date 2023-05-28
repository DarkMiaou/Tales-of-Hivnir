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
        public static Player instance; //permet d'acceder à player dans les autres fichiers
        
        // Bonus de la Classe
        private Classe _ChosenClasse;

        private bool _Wizard;  //Sorcier
        private bool _BonusAttack;    //Barbare
        private bool _BonusArmor; //Berserker
        
        // Bonus de l'Espece
        // Chaque int va avoir 0 -1 ou 1,
        // si on a 1 c'est qu'il y a un bonus à appliquer
        // si on a -1 c'est qu'on a un malus à appliquer 
        private Espece _ChosenEspece;
        
        private int _BonusSpeed;
        private int _BonusStrenght;
        private int _BonusLife;
        
        public PlayerController playercont;

        
        /*
        voici les variables à utilisé pour les combats:
        maxhealth
        bonusdefence
        strenght * bonusattack pour obtenir la valeur de dégats
         */
        
        public int basestrenght = 20;
        public static int strenght;
        public int basemaxhealth = 100;
        public int maxhealth;
        public int currenthealth;
        public float basebonusattack = 1.2f;
        public static float bonusattack;
        public float basebonusdefence = 1.2f;
        public float bonusdefence;

        //public static int Health = 100;
        
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
        public bool Wizard
        {
            get { return _Wizard; }
            set { _Wizard = value; }
        }
        public bool BonusAttack
        {
            get { return _BonusAttack;}
            set
            {
                _BonusAttack = value;
                if (_BonusAttack)
                {
                    bonusattack = basebonusattack + 0.1f;
                }
                else
                {
                    bonusattack = basebonusattack;
                }
            }
        }   
        public bool BonusArmor
        {
            get { return _BonusArmor; }
            set
            {
                _BonusArmor = value;
                if (_BonusArmor)
                {
                    bonusdefence = basebonusdefence + 0.1f;
                }
                else
                {
                    bonusdefence = basebonusdefence;
                }
            }
        }
        public Espece ChosenEspece
        {
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
        public int BonusStrenght
        {
            get { return _BonusStrenght; }
            set
            {
                _BonusStrenght = value;
                switch (_BonusStrenght)
                {
                    case -1:
                        strenght = basestrenght * 3 / 4;
                        break;
                    case 1:
                        strenght = basestrenght * 5 / 4;
                        break;
                    case 0:
                        strenght = basestrenght;
                        break;
                }
            }

        }
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
        public int BonusLife
        {
            get { return _BonusLife; }
            set
            {
                _BonusLife = value;
                switch (_BonusLife)
                {
                    case -1:
                        maxhealth = basemaxhealth * 3 / 4;
                        break;
                    case 1:
                        maxhealth = basemaxhealth * 5 / 4;
                        break;
                    case 0:
                        maxhealth = basemaxhealth;
                        break;
                }
                
            }
        }

        private void Awake()
        {
            currenthealth = maxhealth;
        }
        
        public int GetCurrentHealth()
        {
            return currenthealth;
        }


        //Pour l'iventaire voir le fichier inventaire de Kyllian
        public void TakeDamage(int damage)
        {
            currenthealth -= damage;
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


        public void Destroy()
        {
            Destroy(gameObject);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TalesofHivnir.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TalesofHivnir.Items;
using Entities.Player;



namespace TalesofHivnir.Menus
{
    public class ClasseEspeceMenu : MonoBehaviour
    {
        public GameObject ClasseEspeceMenuCanva;
        public GameObject ClasseMenu;
        public GameObject EspeceMenu;
        public Player player;


        private void Start()
        {
            if (!SaveData.instance.ClasseEspeceChoisie)
            {
                ClasseEspeceMenuCanva.SetActive(true);
                ClasseMenu.SetActive(true);
                EspeceMenu.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                ClasseEspeceMenuCanva.SetActive(false);
            }
        }

        public void CloseEspeceMenu()
        {
            ClasseEspeceMenuCanva.SetActive(false);
            ClasseMenu.SetActive(false);
            EspeceMenu.SetActive(false);
            Time.timeScale = 1f;
            SaveData.instance.ClasseEspeceChoisie = true;
        }

        public void CloseClasseMenu()
        {
            ClasseMenu.SetActive(false);
            EspeceMenu.SetActive(true);
        }

        public void ChooseClasse(string classe)
        {
            Debug.Log(classe);
            Classe cl = Classe.Paladin;
            switch (classe)
            {
                case "Sorcier":
                    cl = Classe.Sorcier;
                    break;
                case "Barbare":
                    cl = Classe.Barbare;
                    break;
                case "Berserker":
                    cl = Classe.Berserker;
                    break;
                case "Paladin":
                    cl = Classe.Paladin;
                    break;
            }
            player.ChosenClasse = cl;
            CloseClasseMenu();
        }
        
        public void ChooseEspece(string espece)
        {
            Debug.Log(espece);
            Espece es = Espece.Humain;
            switch (espece)
            {
                case "Géant":
                    es = Espece.Géant;
                    break;
                case "Elfe":
                    es = Espece.Elfe;
                    break;
                case "Humain":
                    es = Espece.Humain;
                    break;
                case "Nain":
                    es = Espece.Nain;
                    break;
                case "Orc":
                    es = Espece.Orc;
                    break;
                case "Fée":
                    es = Espece.Fée;
                    break;
            }
            player.ChosenEspece = es;
            CloseEspeceMenu();
        }
        
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TalesofHivnir.Items;


namespace TalesofHivnir.Menus
{
    public class ClasseEspeceMenu : MonoBehaviour
    {
        public GameObject ClasseEspeceMenuCanva;
        public GameObject ClasseMenu;
        public GameObject EspeceMenu;


        private void Start()
        {
            ClasseEspeceMenuCanva.SetActive(true);
            ClasseMenu.SetActive(true);
            EspeceMenu.SetActive(false);
            Time.timeScale = 0f;
        }

        public void CloseEspeceMenu()
        {
            ClasseEspeceMenuCanva.SetActive(false);
            ClasseMenu.SetActive(false);
            EspeceMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void CloseClasseMenu()
        {
            ClasseMenu.SetActive(false);
            EspeceMenu.SetActive(true);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace TalesofHivnir.Menus
{
    public class EchapMenu : MonoBehaviour
    {
        public bool IsPaused = false;
        public GameObject CanvaMenuEchap;


        //detection de la touche echap et gestion ouverture et fermeture du menu echap


        void Start()
        {
            Time.timeScale = 1f;
        }

        void Update()
        {
            //Debug.Log("test");
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("EchapMenu/Echapdetect");
                if (IsPaused)
                {
                    Debug.Log("EchapMenu/Resume");
                    Resume();
                }
                else
                {
                    Debug.Log("EchapMenu/Pause");
                    Pause();
                }
            }
        }

        //fin de la pause
        public void Resume()
        {
            IsPaused = false;
            CanvaMenuEchap.SetActive(false);
            Time.timeScale = 1f;
        }

        //debut de la pause => activation du canvas
        public void Pause()
        {
            IsPaused = true;
            CanvaMenuEchap.SetActive(true);
            Time.timeScale = 0f;
        }






        //utilisé pour les boutons
        public void MainMenu()
        {
            Debug.Log("EchapMenu/MainMenu");
            SceneManager.LoadScene("Menu");
        }

        public void Quit()
        {
            Debug.Log("EchapMenu/Quit");
            Application.Quit();
        }
    }
}

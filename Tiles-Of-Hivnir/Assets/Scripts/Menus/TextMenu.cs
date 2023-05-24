using System;
using System.Net.Mime;
using TalesofHivnir.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TalesofHivnir.Menus
{
    public class TextMenu : MonoBehaviour
    {
        public PNJ PNJ;
        public GameObject TextMenuCanva;
        public Text TEXTE;
        public Image PNJ_IMAGE;
        public Text PNJ_NAME;


        private void Start()
        {
            TextMenuCanva.SetActive(false);
        }

        public void Open()
        {
            TextMenuCanva.SetActive(true);
            
        }

        public void Close()
        {
            TextMenuCanva.SetActive(false);
        }

        public void OpenText(string text)
        {
            Open();
            TEXTE.text = text;
            PNJ_NAME.text = PNJ.name;
            PNJ_IMAGE.sprite = PNJ.icone;
        }
    }
}
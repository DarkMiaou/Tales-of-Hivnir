using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TalesofHivnir.Menus
{
    public class TextMenu : MonoBehaviour
    {
        public GameObject TextMenuCanva;
        public Text Text;


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
            Text.text = text;
        }
    }
}
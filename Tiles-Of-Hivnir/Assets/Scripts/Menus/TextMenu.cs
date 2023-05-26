using System;
using System.Net.Mime;
using TalesofHivnir.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TalesofHivnir.Menus
{
    public class TextMenu : MonoBehaviour
    {
        public PNJ PNJ;
        public GameObject TextMenuCanva;
        public TMP_Text TEXTE;
        public Image PNJ_IMAGE;
        public TMP_Text PNJ_NAME;

        private Transform playerTransform;
        public float interactionRange = 2f;
        public KeyCode interactionKey = KeyCode.F;

        private bool isInRange;

        private void Start()
        {
            TextMenuCanva.SetActive(false);
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= interactionRange)
            {
                if (!isInRange)
                {
                    isInRange = true;
                    Debug.Log("Press 'F' to interact with the NPC.");
                }

                if (Input.GetKeyDown(interactionKey))
                {
                    OpenText(TEXTE.text);
                }
            }
            else
            {
                if (isInRange)
                {
                    isInRange = false;
                    Close();
                }
            }
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
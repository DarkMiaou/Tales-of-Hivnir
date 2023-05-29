using System;
using System.Net.Mime;
using TalesofHivnir.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TalesofHivnir.Items;

namespace TalesofHivnir.Menus
{
    public class TextMenu : MonoBehaviour
    {
        public PNJ PNJ;
        public GameObject TextMenuCanva;
        public TMP_Text TEXTE;
        public Image PNJ_IMAGE;
        public Image PNJ_icon;
        public TMP_Text PNJ_NAME;

        private Transform playerTransform;
        public float interactionRange = 2f;
        public KeyCode interactionKey = KeyCode.F;

        private bool isInRange;
        public Item quest_item;
        public int number_of_item;
        public Item reward;
       
        private bool quest = false;
        
      
    
        public Inventory inv;

        private void Start()
        {
            TextMenuCanva.SetActive(false);
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            int i = 0;
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
                    if (inv.InvList.Count <= 0)
                    {
                        if(quest)
                        {
                            TEXTE.text = PNJ.textdejafaitquete;
                        }
                        else
                        {
                            TEXTE.text = PNJ.text;
                        }
                    }
                    else
                    {
                        while (i < inv.InvList.Count)
                        {
                            if (inv.InvList[i].Name == quest_item.Name)
                            {
                                TEXTE.text = PNJ.textrec;

                                inv.InvList.Add(reward);
                                inv.InvList.Remove(quest_item);

                                inv.ActualiseDisplay();
                                Debug.Log("ca marche");
                                quest = true;
                            }
                            else if (quest)
                            {
                                TEXTE.text = PNJ.textdejafaitquete;
                            }
                            else
                            {
                                TEXTE.text = PNJ.text;
                            }

                            i++;
                        }




                    }
                    OpenText(TEXTE.text);
                    i = 0;
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
            PNJ_NAME.text = PNJ.name;
            PNJ_icon.sprite = PNJ.icone;
    
        }
    }
}
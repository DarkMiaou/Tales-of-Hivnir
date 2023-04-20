using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TalesofHivnir;
using TalesofHivnir.interactable;
using TalesofHivnir.Items;


namespace TalesofHivnir
{
    public class ChestController : MonoBehaviour
    {
        public AudioSource chest;
        private AudioSource audioSource;
        public bool isOpen;
        public Item Content;
        public Inventory InvToFill;
        public bool IsInfiny; //si il est sur true on va pouvoir prendre le même item à l'infini
    
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            chest.volume = 0;
            chest.loop = true;
        }

        private void Update()
        {
        }
        

        public void OpenChest()
        {
            if (!isOpen)
            {
                chest.volume = 1;
                chest.Play();
                chest.loop = false;
                if (InvToFill != null && Content != null)
                {
                    InvToFill.AddItem(Content, this);
                }
              
                isOpen = true;
                Debug.Log("Chest is open");
                
                

            }
           
            
        }

        public void CloseChest()
        {
            if (isOpen)
            {
                isOpen = false;
                Debug.Log("chest closed");
                chest.volume = 0;
                chest.loop = true;
            }
        }

    }
}






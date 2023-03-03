using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TalesofHivnir.Items;


namespace TalesofHivnir.Menus
{
    public class InvMenu : MonoBehaviour
    {
        public GameObject InvMenuCanva;
        public Image Imagetochange;
        public bool IsPaused = false;
        public GameObject ItemNullCanvas;
        
        public GameObject ItemCanvas;
        public Image Icone;
        public Text Nom;
        
        public GameObject Invfull;
        public Text ChoiceA;
        public Text ChoiseB;
        public bool ItemNotTaken;
        
        public GameObject Invnotfull;


        private void Start()
        {
            InvMenuCanva.SetActive(false);
            ItemNullCanvas.SetActive(false);
            ItemCanvas.SetActive(false);
            Invfull.SetActive(false);
            Invnotfull.SetActive(false);
        }

        public void Pause()
        {
            Debug.Log("MenuInv/Pause");
            IsPaused = true;
            InvMenuCanva.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            InvMenuCanva.SetActive(false);
            ItemNullCanvas.SetActive(false);
            ItemCanvas.SetActive(false);
            Invfull.SetActive(false);
            Invnotfull.SetActive(false);
            Time.timeScale = 1f;
        }

        public void ItemNullDiplay()
        {
            Debug.Log("MenuInv/ItemNullDiplay");
            Pause();
            ItemNullCanvas.SetActive(true);
        }

        public void ItemDiplay(Item item)
        {
            Debug.Log("MenuInv/ItemDiplay");
            Pause();
            ItemCanvas.SetActive(true);
            Icone.sprite = item.Icone;
            Nom.text = item.Name;
        }
        public bool InvFullDisplay(Inventory inv, Item item)
        {
            ItemDiplay(item);
            Invfull.SetActive(true);
            ChoiceA.text = "- Don't take the " + item.Name;
            ChoiseB.text = "Throw an object and take the " + item.Name + " instead";
            return ItemNotTaken;
        }

        public void DontTakeItem()
        {
            ItemNotTaken = true;
            Resume();
        }

        public void ChangeItem(int i)
        {
            ItemNotTaken = false;
            
        }
        
        
        
        //public void Test()
    }
}

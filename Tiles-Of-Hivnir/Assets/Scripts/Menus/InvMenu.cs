using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TalesofHivnir.Items;
using TMPro;


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
        public TMP_Text Nom;
        
        public GameObject Invfull;
        public TMP_Text ChoiceA;
        public TMP_Text ChoiseB;
        public bool ItemNotTaken;
        public Inventory InvToAdd;
        public Item ItemToAdd;
        public GameObject ErrorChoiceBInvFull;

        public GameObject Invnotfull;
        public TMP_Text ChoiceAbis;
        public TMP_Text ChoiceBbis;


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
            ErrorChoiceBInvFull.SetActive(false);
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
            InvToAdd = inv;
            ItemToAdd = item;
            ChoiceA.text = "- Don't take the " + item.Name;
            ChoiseB.text = "- Throw an object and take the " + item.Name + " instead";
            return ItemNotTaken;
        }

        public void DontTakeItem()
        {
            ItemNotTaken = true;
            Resume();
        }

        public void Echange(int i) //Inutile en Théorie mais évite de faire des dingz
        {
            if (InvToAdd.InvList.Count-1 < i)
            {
                ErrorChoiceBInvFull.SetActive(true);
            }
            else
            {
                if (InvToAdd.InvList[i] is Weapon)
                {
                    SaveData.instance.damage -=  InvToAdd.InvList[i].Level;
                }
                else
                { 
                    SaveData.instance.maxhealth -=  InvToAdd.InvList[i].Level;
                    SaveData.instance.currenthealth -=  InvToAdd.InvList[i].Level;
                }

                if (ItemToAdd is Weapon)
                {
                    SaveData.instance.damage += ItemToAdd.Level;
                }
                else
                {
                    SaveData.instance.maxhealth += ItemToAdd.Level;
                    SaveData.instance.currenthealth += ItemToAdd.Level;
                }
                InvToAdd.InvList[i] = ItemToAdd;
                InvToAdd.ActualiseDisplay();
                Resume();
                
            }
        }
        
        public bool InvNotFullDisplay(Inventory inv, Item item){
            
            ItemDiplay(item);
            Invnotfull.SetActive(true);
            InvToAdd = inv;
            ItemToAdd = item;
            ChoiceAbis.text = "- Don't take the " + item.Name;
            ChoiceBbis.text = "- Take the " + item.Name;
            return ItemNotTaken;
        }

        public void Add()
        {
            ItemNotTaken = false;
            if (ItemToAdd is Weapon)
            {
                SaveData.instance.damage += ItemToAdd.Level;
            }
            else
            {
                SaveData.instance.maxhealth += ItemToAdd.Level;
                SaveData.instance.currenthealth += ItemToAdd.Level;
            }

            InvToAdd.InvList.Add(ItemToAdd);
            InvToAdd.ActualiseDisplay();
            Resume();
        }
        
        
        //public void Test()
    }
    
}

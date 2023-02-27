using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestController : MonoBehaviour
{
    public bool isOpen;
    
    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest is open");
        }
    }
    public void CloseChest()
    {
        if (isOpen)
        {
            isOpen = false;
            Debug.Log("Chest is closed");
        }
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TalesofHivnir;
using TalesofHivnir.interactable;
using TalesofHivnir.Items;


namespace TalesofHivnir
{
    public class DoorController : MonoBehaviour
    {
        public bool isOpen;
        
    
        public void OpenDoor()
        {
            if (!isOpen)
            {
                isOpen = true;
                Debug.Log("Door is open");
            }
        }
        
        public void CloseDoor()
        {
            if (isOpen)
            {
                isOpen = false;
                Debug.Log("door closed");
            }
        }

    }
}






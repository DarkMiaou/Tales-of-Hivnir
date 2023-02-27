using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TalesofHivnir
{
    public class interactable : MonoBehaviour
    {

        public bool isInRange;
        public KeyCode interactKey;
        public UnityEvent interactAction;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(isInRange) // si inRange
            {
                if (Input.GetKeyDown(interactKey))  // si F appuyé
                {
                    interactAction.Invoke(); // lancer l action
                }
            
            }
        
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log("Player is in range");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                Debug.Log("Player is not in range");
            }
        }
    }

}
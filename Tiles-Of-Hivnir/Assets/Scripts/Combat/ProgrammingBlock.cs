using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TalesofHivnir
{
    public class ProgrammingBlock : MonoBehaviour
    {

        public string blockName; // le nom du block
        public int blockType; // le type de block
        public float speed = 5f;
        //Rigidbody2D rb;// la valeur du block genre vitesse durée etc 
        public GameObject objectToMove;
        private Animator myAnim;


        public void Execute()
        {
            Rigidbody2D rb = objectToMove.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Object to move has no Rigidbody2D component");
                return;
            }
            switch (blockType)
            {
                case 0:
                    MoveUp();
                    // Le bloc qu'il devra call 
                    break; 
                case 1:
                    MoveDown();
                    // Le bloc qu'il devra call 
                    break;
                case 2:
                    MoveLeft();
                    // Le bloc qu'il devra call 
                    break;
                case 3:
                    MoveRigth();
                    // Le bloc qu'il devra call 
                    break;
                case 4:
                    Attack();
                    break;
                case 5:
                    MoveLeftCheat();
                    break;
            }
        }

        void MoveUp()
        {
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(0, 1f, 0), 0.5f));


        }

        void MoveDown()
        {
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(0, -1f, 0), 0.5f));


        }
        
        void MoveLeft()
        {
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(-1f, 0, 0), 0.5f));


        }

        void MoveLeftCheat()
        {
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(-16f, 0, 0), 0.5f));

        }
        
        void MoveRigth()
        {
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(1f, 0, 0), 0.5f));


        }

        void Attack()
        {
            LogMonster.Attack();
        }
        
        IEnumerator MoveObjectToPosition(GameObject objectToMove, Vector3 moveVector, float duration)
        {
            Vector3 startPosition = objectToMove.transform.position;
            Vector3 targetPosition = startPosition + moveVector;
            float startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                float t = (Time.time - startTime) / duration;
                objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                yield return null;
            }

            objectToMove.transform.position = targetPosition;
        }
    }

}


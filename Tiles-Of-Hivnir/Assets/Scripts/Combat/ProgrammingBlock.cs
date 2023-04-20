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

        
        void Start()
        {
            //rb = GetComponent<Rigidbody2D>();
        }

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
            }
        }

        void MoveUp()
        {
            /*Vector2 newPosition = new Vector2(transform.position.x , transform.position.y + 1);
            rb.MovePosition(newPosition);*/
            //objectToMove.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(0, 1f, 0), 0.5f));

        }

        void MoveDown()
        {
            /*Vector2 newPosition = new Vector2(transform.position.x , transform.position.y -1);
            rb.MovePosition(newPosition);*/
            //objectToMove.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(0, -1f, 0), 0.5f));


        }
        
        void MoveLeft()
        {
            /*Vector2 newPosition = new Vector2(transform.position.x - 1, transform.position.y);
            rb.MovePosition(newPosition);*/
            //objectToMove.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            StartCoroutine(MoveObjectToPosition(objectToMove, new Vector3(-1f, 0, 0), 0.5f));


        }
        
        void MoveRigth()
        {
            /*Vector2 newPosition = new Vector2(transform.position.x + 1, transform.position.y);
            rb.MovePosition(newPosition);*/
            //objectToMove.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
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


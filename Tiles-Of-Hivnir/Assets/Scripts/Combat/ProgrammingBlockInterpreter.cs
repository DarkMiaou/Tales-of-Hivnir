using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace TalesofHivnir
{
    
    public class ProgrammingBlockInterpreter : MonoBehaviour
    {
        public Transform playcoord;
        public Transform mobcoord;
        public GameObject player;
        public float mobhealth;
        public float playerhealth;
        public float mobattack;
        public float playerattack;
       
        private float timer = 60f;
        private int randomAction;
        public GameObject objectToMove;
        private bool isInterpreting = false;
        public List<ProgrammingBlock> blockList;
        private Transform target;// list des block de prog
        private float coordx;
        private float coordy;
        private int Horizontal;
        private int Vertical;
        public Animator mobanim;

        public static List<RectTransform> blocks;
        public RectTransform startBlock;

        public static List<RectTransform> Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        public void Start()
        {
            Blocks = new List<RectTransform>();
            Blocks.Add(startBlock);
        }


        public float blockExecutionDelay = 0.5f;

        public void InterpretBlock()
        {
            StartCoroutine(ExecuteBlockSequence());
        }

        private IEnumerator ExecuteBlockSequence()
        {
           
            coordx = playcoord.position.x - mobcoord.position.y;
            coordy = playcoord.position.y - mobcoord.position.y;
            isInterpreting = true;
            
            foreach (ProgrammingBlock block in blockList)
            {
                block.Execute();
                yield return new WaitForSeconds(blockExecutionDelay);
              
            }
            blockList = new List<ProgrammingBlock>();
            Blocks = new List<RectTransform>();
            Blocks.Add(startBlock);
        }
        
        public void AddBlock(ProgrammingBlock block)
        {
            coordx = playcoord.position.x - mobcoord.position.y;
            coordy = playcoord.position.y - mobcoord.position.y;
            if (!blockList.Contains(block))
            {
                blockList.Add(block);
            }
        }
        

        private void Update()
        {
            coordx = playcoord.position.x - mobcoord.position.y;
            coordy = playcoord.position.y - mobcoord.position.y;

          
            timer -= Time.deltaTime;
            if (timer <= 0f || isInterpreting)
            {
                isInterpreting = false;
                timer = 60f;

                if (coordx >= 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.right, 1));
                    coordx = playcoord.position.x - mobcoord.position.y;
                    coordy = playcoord.position.y - mobcoord.position.y;
                    mobanim.SetInteger(Horizontal,1);
                    Debug.Log("droite");
                 
                }
                else if (coordx < 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.left, 1));
                    coordx = playcoord.position.x - mobcoord.position.y;
                    coordy = playcoord.position.y - mobcoord.position.y;
                    mobanim.SetInteger(Horizontal,-1);
                    Debug.Log("gauche");
               
                }
                else if (coordy >= 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.up, 1));
                    coordx = playcoord.position.x - mobcoord.position.y;
                    coordy = playcoord.position.y - mobcoord.position.y;
                    mobanim.SetInteger(Vertical,1);
                    Debug.Log("haut");
             
                }
                else if (coordy < 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.down, 1));
                    coordx = playcoord.position.x - mobcoord.position.y;
                    coordy = playcoord.position.y - mobcoord.position.y;
                    mobanim.SetInteger(Vertical,-1);
                    
                    Debug.Log("bas");
          
                }
                else
                {
                    Attack();
                    coordx = playcoord.position.x - mobcoord.position.y;
                    coordy = playcoord.position.y - mobcoord.position.y;
                    
                    Debug.Log("attaque");
                }

                new WaitForSeconds(2);
                Horizontal = 0;
                Vertical = 0;

            }

           
        }

        private void Attack()
        {
            playerhealth -= mobattack;
            if (playerhealth <= 0)
            {
                SceneManager.LoadScene("Test");
            }
        }

        private IEnumerator MoveObjectToPosition(GameObject objectToMove, Vector3 moveVector, float duration)
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

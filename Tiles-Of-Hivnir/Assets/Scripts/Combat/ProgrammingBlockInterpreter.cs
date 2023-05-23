using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TalesofHivnir
{
    
    public class ProgrammingBlockInterpreter : MonoBehaviour
    {
        public Transform playcoord;
        public Transform mobcoord;
        public GameObject player;
       
        private float timer = 60f;
        private int randomAction;
        public GameObject objectToMove;
        private bool isInterpreting = false;
        public List<ProgrammingBlock> blockList;
        private Transform target;// list des block de prog
        private float coordx;
        private float coordy;

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
        }
        
        public void AddBlock(ProgrammingBlock block)
        {
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
                randomAction = Random.Range(1, 6);

                if (coordx >= 0 && coordx >= coordy)
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.right, 1));
                    playcoord = player.transform;
                    mobcoord = objectToMove.transform;
                }
                else if (coordx < 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.left, 1));
                    playcoord = player.transform;
                    mobcoord = objectToMove.transform;
                }
                else if (coordy >= 0 && coordy >= coordx)
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.up, 1));
                    playcoord = player.transform;
                    mobcoord = objectToMove.transform;
                }
                else if (coordy < 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.down, 1));
                    playcoord = player.transform;
                    mobcoord = objectToMove.transform;
                }
                else
                {
                    Attack();
                    playcoord = player.transform;
                    mobcoord = objectToMove.transform;
                }
               
            }

           
        }

        private void Attack()
        {
            // Code pour l'attaque
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

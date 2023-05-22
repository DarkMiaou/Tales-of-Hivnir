using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TalesofHivnir
{
    
    public class ProgrammingBlockInterpreter : MonoBehaviour
    {
       
        private float timer = 60f;
        private int randomAction;
        public GameObject objectToMove;
        private bool isInterpreting = false;
        public List<ProgrammingBlock> blockList;
        public float checkradius;
        public float attackrange;
        private bool IsInchaserange;
        private bool IsInAttackRange;
        private Transform target;// list des block de prog
        
        
        public float blockExecutionDelay = 0.5f;

        public void InterpretBlock()
        {
            StartCoroutine(ExecuteBlockSequence());
        }

        private IEnumerator ExecuteBlockSequence()
        {isInterpreting = true;
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
            timer -= Time.deltaTime;
            if (timer <= 0f || isInterpreting)
            {
                isInterpreting = false;
                timer = 60f;
                randomAction = Random.Range(1, 6);
                if (IsInAttackRange)
                {
                    throw new NotImplementedException();
                }
                if (IsInchaserange)
                {
                    throw new NotImplementedException();
                }
                switch (randomAction)
                {
                    case 1:
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.up, 1));
                        break;
                    case 2:
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.down, 1));
                        break;
                    case 3:
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.left, 1));
                        break;
                    case 4:
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.right, 1));
                        break;
                    case 5:
                        Attack();
                        break;
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

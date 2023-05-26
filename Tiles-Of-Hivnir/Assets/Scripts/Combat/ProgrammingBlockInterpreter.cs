using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        private float coordx;
        private float coordy;

        public Animator mobanim;

        public static List<RectTransform> blocks;
        public RectTransform startBlock;

        [SerializeField] private Button ClearButton;

        public static List<RectTransform> Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        private void Start()
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
            coordx = playcoord.position.x - mobcoord.position.x;
            coordy = playcoord.position.y - mobcoord.position.y;
            isInterpreting = true;

            foreach (ProgrammingBlock block in blockList)
            {
                block.Execute();
                yield return new WaitForSeconds(blockExecutionDelay);
            }

            ClearBlocks();
        }

        public void AddBlock(ProgrammingBlock block)
        {
            coordx = playcoord.position.x - mobcoord.position.x;
            coordy = playcoord.position.y - mobcoord.position.y;
            if (!blockList.Contains(block))
            {
                blockList.Add(block);
            }
        }

        private void Update()
        {
            coordx = playcoord.position.x - mobcoord.position.x;
            coordy = playcoord.position.y - mobcoord.position.y;

            timer -= Time.deltaTime;
            if (timer <= 0f || isInterpreting)
            {
                isInterpreting = false;
                timer = 60f;

                if (coordx >= 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.right, 0.5f));
                    mobanim.SetTrigger("Right");
                    ResetAnimationTrigger("Right");
                    Debug.Log("Right");
                }
                else if (coordx < 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.left, 0.5f));
                    mobanim.SetTrigger("Left");
                    ResetAnimationTrigger("Left");
                    Debug.Log("Left");
                }
                else if (coordy >= 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.up, 0.5f));
                    mobanim.SetTrigger("Up");
                    ResetAnimationTrigger("Up");
                    Debug.Log("Up");
                }
                else if (coordy < 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.down, 0.5f));
                    mobanim.SetTrigger("Down");
                    ResetAnimationTrigger("Down");
                    Debug.Log("Down");
                }
                else
                {
                    // No movement, set the animation to the default state (e.g., idle)
                    mobanim.SetTrigger("Idle");
                    ResetAnimationTrigger("Idle");
                    Debug.Log("Idle");
                }
            }
        }
        private IEnumerator ResetAnimationTrigger(string triggerName)
        {
            yield return new WaitForSeconds(1f); // Adjust the delay as needed
            mobanim.ResetTrigger(triggerName);
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

        public void ClearBlocks()
        {
            for (int i = 1; i < Blocks.Count; i++)
            {
                Destroy(Blocks[i].gameObject);
            }
            blockList = new List<ProgrammingBlock>();
            Blocks = new List<RectTransform>();
            Blocks.Add(startBlock);
        }
    }
}

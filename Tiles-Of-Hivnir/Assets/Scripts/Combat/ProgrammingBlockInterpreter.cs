using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TalesofHivnir.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TalesofHivnir
{
    public class ProgrammingBlockInterpreter : PlayerCombat
    {
        
        public Transform playcoord;
        public Transform mobcoord;
     
        public float mobhealth = LogMonster.LifeLog;
        public int mobcurrenthealth;
        public int mobattack;
        public int playerattack;

        private float timer = 60f;
        private int randomAction;
        public GameObject objectToMove;
        private bool isInterpreting = false;
        public List<ProgrammingBlock> blockList;
        private float coordx;
        private float coordy;
        public GameObject attaque;
        public GameObject move;
        public TMP_Text textPa;
        
        public Animator mobanim;

        public static List<RectTransform> blocks;
        public RectTransform startBlock;

        public GameObject gameoverUI;
        public int PA= 0;
        public int Max_PA;
        

        private Button ClearButton;
        

        public static List<RectTransform> Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        private void Start()
        {

            Blocks = new List<RectTransform>();
            Blocks.Add(startBlock);
            move.SetActive(false);
            attaque.SetActive(false);


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
            PA = 0;
            ClearBlocks();

        }

        public void AddBlock(ProgrammingBlock block)
        {
            coordx = playcoord.position.x - mobcoord.position.x;
            coordy = playcoord.position.y - mobcoord.position.y;
            if (!blockList.Contains(block))
            {
                blockList.Add(block);
                PA++;   
            }
        }

        public void Remove(ProgrammingBlock block)
        {
            Destroy(Blocks[Blocks.Count-1].gameObject);
            Blocks.Remove(Blocks[Blocks.Count-1]);
            blockList.Remove(block);
            PA--;
        }

        private void Update()
        {
            textPa.text = Convert.ToString(Max_PA-PA);
            //Debug.Log(Blocks.Count);
            coordx = playcoord.position.x - mobcoord.position.x;
            coordy = playcoord.position.y - mobcoord.position.y;
            timer -= Time.deltaTime;
            int index = blockList.Count -1;
           
            if (PA > Max_PA)
            {
                Remove(blockList[index ]);
            }
               
          
            if (timer <= 0f || isInterpreting)
            {
                isInterpreting = false;
                timer = 60f;

                if (Math.Abs(coordy) <= 1 && Math.Abs(coordx) >= 0 && Math.Abs(coordx) <=1 && Math.Abs(coordx)>=0)
                {
                    mobanim.SetFloat("Horizontal", 0);
                    mobanim.SetFloat("Vertical", 0);
                    Attack();
                    
                    Debug.Log("attack");
                }
                else
                {
                    if (coordx >= 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                    {
                        mobanim.SetFloat("Horizontal",1 );
                        mobanim.SetFloat("Vertical", 0);
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.right, 0.5f));
                        
                        Debug.Log("Right");
                    }
                    else if (coordx < 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                    {
                        mobanim.SetFloat("Horizontal", -1);
                        mobanim.SetFloat("Vertical", 0);
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.left, 0.5f));
                        Debug.Log("Left");
                    }
                    else if (coordy >= 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                    {
                        mobanim.SetFloat("Horizontal", 0);
                        mobanim.SetFloat("Vertical", 1);
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.up, 0.5f));
                       
                        Debug.Log("Up");
                    }
                    else if (coordy < 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                    {
                        mobanim.SetFloat("Horizontal", 0);
                        mobanim.SetFloat("Vertical", -1);
                        StartCoroutine(MoveObjectToPosition(objectToMove, Vector3.down, 0.5f));
                        
                        Debug.Log("Down");
                    }
                }
                
            }
            else
            {  
                if (Math.Abs(coordy) <= 1 && Math.Abs(coordx) >= 0 && Math.Abs(coordx) <=1 && Math.Abs(coordx)>=0)
                { 
                    attaque.SetActive(true);
                    move.SetActive(false);
                   
                }
                else  if (coordx < 0 && Math.Abs(coordx) >= Math.Abs(coordy))
                {
                    attaque.SetActive(false);
                    move.SetActive(true);
                 
                }
                else if (coordy > 1 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    attaque.SetActive(false);
                    move.SetActive(true);
                   
                }
                else if (coordy < 0 && Math.Abs(coordy) >= Math.Abs(coordx))
                {
                    attaque.SetActive(false);
                    move.SetActive(true);
              
                }
                else if (coordx > 1 && Math.Abs(coordx) >= Math.Abs(coordy))
                { 
                    attaque.SetActive(false);
                    move.SetActive(true);
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
            SaveData.instance.currenthealth -= 20;
            GotDamage();
            

            if (SaveData.instance.currenthealth <= 0 && !isDead)
            {
                isDead = true;
                gameOver();
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
                PA = 0;
            }
            blockList = new List<ProgrammingBlock>();
            Blocks = new List<RectTransform>();
            Blocks.Add(startBlock);
           

        }

        public void gameOver()
        {
            gameoverUI.SetActive(true);
        }

        public void restart()
        {
            //Player.instance.currenthealth = Player.instance.maxhealth;
            SaveData.instance.currenthealth = SaveData.instance.maxhealth;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Mainmenu()
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
}

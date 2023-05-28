using System;
using System.Collections;
using System.Collections.Generic;
using TalesofHivnir.Entities;
using UnityEngine;

namespace TalesofHivnir
{
    public class ProgrammingBlock : LogMonster
    {
        public string blockName;
        public int blockType;
        public float speed = 5f;
        public GameObject objectToMove;
        public Animator myanim;
        private float damage;

        private Rigidbody2D rb;
        private bool isMoving = false;

        private void Start()
        {
            damage = 20;
            Debug.Log(damage);
            rb = objectToMove.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Object to move has no Rigidbody2D component");
            }
        }

        public void Execute()
        {
            if (!isMoving)
            {
                switch (blockType)
                {
                    case 0:
                        MoveUp();
                        break;
                    case 1:
                        MoveDown();
                        break;
                    case 2:
                        MoveLeft();
                        break;
                    case 3:
                        MoveRight();
                        break;
                    case 4:
                        Attack();
                        break;
                    case 5:
                        MoveLeftCheat();
                        break;
                }
            }
        }

        private void MoveUp()
        {
            StartCoroutine(MoveObjectToPosition(new Vector3(0, 1f, 0), 0.5f));
            myanim.SetFloat("Vertical", 1);
            isMoving = true;
        }

        private void MoveDown()
        {
            StartCoroutine(MoveObjectToPosition(new Vector3(0, -1f, 0), 0.5f));
            myanim.SetFloat("Vertical", -1);
            isMoving = true;
        }

        private void MoveLeft()
        {
            StartCoroutine(MoveObjectToPosition(new Vector3(-1f, 0, 0), 0.5f));
            myanim.SetFloat("Horizontal", -1);
            myanim.SetFloat("Vertical", 0);
            isMoving = true;
        }

        private void MoveRight()
        {
            StartCoroutine(MoveObjectToPosition(new Vector3(1f, 0, 0), 0.5f));
            myanim.SetFloat("Horizontal", 1);
            myanim.SetFloat("Vertical", 0);
            isMoving = true;
        }

        private void MoveLeftCheat()
        {
            StartCoroutine(MoveObjectToPosition(new Vector3(-16f, 0, 0), 0.5f));
            myanim.SetFloat("Horizontal", -1);
            isMoving = true;
        }

        private void Attack()
        {
            myanim.SetFloat("Horizontal", 0.2f);
            myanim.SetFloat("Vertical", 0.2f);
            Debug.Log(damage);
            EnemyCombat.instance.TakeDamage(damage);
        }





        private IEnumerator MoveObjectToPosition(Vector3 moveVector, float duration)
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
            isMoving = false;
        }

        // Animation event to reset the animation parameters
        private void ResetAnimationParameters()
        {
            myanim.SetFloat("Vertical", 0);
            myanim.SetFloat("Horizontal", 0);
        }
    }
}

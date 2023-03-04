using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TalesofHivnir
{

    public class PlayerController : MonoBehaviour
    {
        public int Speed;
        Vector2 movement;

        public float moveSpeed = 5f;
        public Transform movePoint;
        public LayerMask whatStopsMovement;
        public Animator anim;
        public Inventory Inv;

        // La variable qui va stocker si le joueur peut se déplacer ou non
        bool canMove = true;

        // Start is called before the first frame update
        void Start()
        {
            movePoint.parent = null;

        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            movement.x = 0f;
            movement.y = 0f;

            if (Mathf.Abs(horizontalInput) > 0.5f)
            {
                movement.x = horizontalInput;
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", 0f);
            }
            else if (Mathf.Abs(verticalInput) > 0.5f)
            {
                movement.y = verticalInput;
                anim.SetFloat("Horizontal", 0f);
                anim.SetFloat("Vertical", movement.y);
            }
            else
            {
                anim.SetFloat("Horizontal", 0f);
                anim.SetFloat("Vertical", 0f);
            }

            anim.SetFloat("Speed", movement.magnitude);

            if (canMove) // On ne déplace le joueur que s'il peut se déplacer
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            }

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (Mathf.Abs(horizontalInput) == 1f)
                {
                    if (!Physics2D.OverlapCircle(
                            movePoint.position + new Vector3(horizontalInput, 0f, 0f),
                            .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(horizontalInput, 0f, 0f);
                        canMove = true; // On réinitialise canMove à true si le joueur peut se déplacer
                    }
                    else
                    {
                        canMove = false; // Sinon, le joueur ne peut pas se déplacer dans cette direction
                    }
                }
                else if (Mathf.Abs(verticalInput) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalInput, 0f),
                            .2f,
                            whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, verticalInput, 0f);
                        canMove = true;
                    }
                    else
                    {
                        canMove = false;
                    }
                }
            }

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }
    }
}

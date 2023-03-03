using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TalesofHivnir
{


    public class PlayerController : MonoBehaviour
    {
        //Stats du joueur
        //public int Health;
        //public int Strength;
        public int Speed;
        Vector2 movement;


        public float moveSpeed = 5f;
        public Transform movePoint;
        public LayerMask whatStopMovement;
        public Animator anim;
        public Inventory Inv;

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

            transform.position =
                Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (Mathf.Abs(horizontalInput) == 1f)
                {
                    if (!Physics2D.OverlapCircle(
                            movePoint.position + new Vector3(horizontalInput, 0f, 0f),
                            .2f, whatStopMovement))
                    {
                        movePoint.position += new Vector3(horizontalInput, 0f, 0f);
                    }
                }
                else if (Mathf.Abs(verticalInput) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalInput, 0f),
                            .2f,
                            whatStopMovement))
                    {
                        movePoint.position += new Vector3(0f, verticalInput, 0f);
                    }
                }
            }
        }
    }
}
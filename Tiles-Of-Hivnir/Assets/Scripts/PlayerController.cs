using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TalesofHivnir
{


    public class PlayerController : MonoBehaviour
    {
        //Stats du joueur
        public int Health;
        public int Strength;
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
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
            transform.position =
                Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(
                            movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),
                            .2f, whatStopMovement))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f),
                            .2f,
                            whatStopMovement))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    }
                }
            }
        }
    }
}

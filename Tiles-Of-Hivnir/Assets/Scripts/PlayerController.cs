using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private BoxCollider2D BoxCollider;
    private Animator myAnim;
    private Vector3 moveDelta;

    [SerializeField]
    private float speed;
    
    //Item
    public Item[] Inventory;
   
    
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        
        // Mouvement du personnage
        myRB.velocity = new Vector2(Input.GetAxis("Horizontal")* speed * Time.deltaTime, Input.GetAxis("Vertical")* speed * Time.deltaTime);

        // Animation du personnage (le sprite en fonction de la direction)
        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);
        
        // Idle Animation Condition
        if (X == 1 || X == -1 || Y == 1 || Y == -1)
        {
            myAnim.SetFloat("lastMoveX", X);
            myAnim.SetFloat("lastMoveY", Y);
        }



    }
}

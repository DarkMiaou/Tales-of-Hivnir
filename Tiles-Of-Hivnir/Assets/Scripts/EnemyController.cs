using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public AudioSource detectsound;
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public bool HaveToRotate;
    public LayerMask WhatisPlayer;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    private Vector2 lastMove;
    private bool IsInchaserange;
    private bool IsInAttackRange;
    // Start is called before the first frame update
    void Start()
    {
     
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsInchaserange)
        {
            detectsound.Play();
        }
        anim.SetBool("Isrunning", IsInchaserange);

        IsInchaserange = Physics2D.OverlapCircle(transform.position, checkRadius, WhatisPlayer);
        IsInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, WhatisPlayer);

        if (IsInchaserange && !IsInAttackRange)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            movement = new Vector2(Mathf.Round(dir.x), Mathf.Round(dir.y));
            lastMove = movement;

            if (HaveToRotate)
            {
                anim.SetFloat("X", lastMove.x);
                anim.SetFloat("Y", lastMove.y);
            }
        }
        else
        {
            movement = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (movement.magnitude > 0)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, rb.position + movement, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}

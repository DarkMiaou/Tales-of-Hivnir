using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject transformm; 
    private NavMeshAgent monster;
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
    private string m_SceneName = "COMBATMODE";
    public Transform player;

    public GameObject pla;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        monster=GetComponent<NavMeshAgent>();
        monster.updateRotation = false;
        monster.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            Vector2 moveDirection = (target.position - transform.position).normalized;
            rb.velocity = moveDirection * speed;
        }
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
             
            lastMove = movement;
            monster.SetDestination(target.position);
            if (HaveToRotate)
            {
                anim.SetFloat("X", lastMove.x);
                anim.SetFloat("Y", lastMove.y);
            }
        }

        if (IsInAttackRange)
        {
            StartCoroutine(LoadYourAsyncScene());
        }
        else
        {
            // Enlevez les deux lignes ci-dessous
            //monster.SetDestination(player.position);
            //movement = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
    }

   
    IEnumerator LoadYourAsyncScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_SceneName, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(target.gameObject, SceneManager.GetSceneByName(m_SceneName));
    
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
    void Awake()
    {
        // Définir cet objet en tant qu'objet persistant
        DontDestroyOnLoad(gameObject);
    }
}
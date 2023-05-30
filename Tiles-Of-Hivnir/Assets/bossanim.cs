using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossanim : MonoBehaviour
{
    private float time = 5f;
    private int randomAction;
    private Animator anim;
    private int randomy;
    private bool idlerandom = false;
    private bool ismoving = false;
    public Transform playerTransform;
    public int range;
    public string scene;


    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= range) 
        {
            SceneManager.LoadScene(scene);
        }
        time -= Time.deltaTime;
        randomAction = Random.Range(-1, 1);
        randomy = Random.Range(-1, 1);
        if (time <= 0f)
        {
            time = 10f;
            idlerandom = true;
            anim.SetBool("randomidle", idlerandom);

           
            anim.SetFloat("Random", randomAction);
            anim.SetFloat("RandomY", randomy);

            StartCoroutine(WaitAndSetIdleFalse());
        }
    }

    IEnumerator WaitAndSetIdleFalse()
    {
        yield return new WaitForSeconds(6);
        idlerandom = false;
        anim.SetBool("randomidle", idlerandom);
    }
}

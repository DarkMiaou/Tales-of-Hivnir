using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeai : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRadius = 5f;
    public float pauseDuration = 2f;

    private Vector3 moveTarget;
    private bool isMoving = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Initialisation de la position cible
        moveTarget = GetRandomPosition();
    }

    void Update()
    {
        if (!isMoving)
        {
            // Si le mob n'est pas en train de se déplacer, on démarre une pause
            StartCoroutine(Pause());

            // On met l'animation en état d'attente (idle)
            anim.SetFloat("Horizontal", 0f);
            anim.SetFloat("Vertical", -1f);
            anim.SetBool("isMoving", false);
        }
        else
        {
            // Si le mob est en train de se déplacer, on le fait avancer vers sa position cible
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, moveSpeed * Time.deltaTime);

            // Si le mob a atteint sa position cible, on lui donne une nouvelle position cible aléatoire
            if (transform.position == moveTarget)
            {
                isMoving = false;
                moveTarget = GetRandomPosition();
            }
            else
            {
                // On détermine la direction du déplacement pour l'animation
                Vector2 direction = (moveTarget - transform.position).normalized;
                anim.SetFloat("Horizontal", direction.x);
                anim.SetFloat("Vertical", direction.y);
                anim.SetBool("isMoving", true);
            }
        }
    }

    // Fonction pour obtenir une position aléatoire dans le rayon donné
    Vector3 GetRandomPosition()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        float distance = Random.Range(0, moveRadius);
        Vector3 position = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * distance;
        position.z = 0f;
        return position;
    }

    // Fonction pour démarrer une pause avant de donner une nouvelle position cible
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(pauseDuration);
        isMoving = true;
    }
    
    // Fonction pour gérer les collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        // Si on entre en collision avec un objet, on choisit une nouvelle direction
        moveTarget = GetRandomPosition();
    }
}

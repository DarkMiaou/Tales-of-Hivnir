using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passifia : MonoBehaviour
{
    
    public float moveSpeed = 2f;
    public float moveRadius = 5f;
    public float pauseDuration = 2f;
    public float collisionCheckRadius = 0.2f;
    private float timer = 5f;

    private Vector3 moveTarget;
    private bool isMoving = false;

    private Animator anim;
    private int random;

        void Start()
        {
            anim = GetComponent<Animator>();

            // Initialisation de la position cible
            moveTarget = GetRandomPosition();
        }

        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                random = Random.Range(-3, 3);
                moveTarget = new Vector3(transform.position.x + random, transform.position.y + random, 0);
                timer = 5f;
            }

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

                // Si le mob est suffisamment proche de sa position cible, on lui donne une nouvelle position cible aléatoire
                if (Vector3.Distance(transform.position, moveTarget) < 0.1f)
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
            Vector3 position = transform.position;
            bool foundPosition = false;

            while (!foundPosition)
            {
                float angle = Random.Range(0, 2 * Mathf.PI);
                float distance = Random.Range(0, moveRadius);

                position = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * distance;
                position.z = 0f;

                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, collisionCheckRadius);

                if (colliders.Length == 0)
                {
                    foundPosition = true;
                }
            }

            return position;
        }

        // Fonction pour démarrer une pause avant de donner une nouvelle position cible
        IEnumerator Pause()
        {
            yield return new WaitForSeconds(pauseDuration);
            isMoving = true;
        }

        // Dessine le cercle de collision dans l'éditeur
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, collisionCheckRadius);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, moveRadius);
        }
    }



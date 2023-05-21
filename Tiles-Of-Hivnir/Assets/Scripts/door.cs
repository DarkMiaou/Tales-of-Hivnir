using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using TalesofHivnir.Entities;
using UnityEngine;

public class door : MonoBehaviour

{


    public GameObject player;

    // Définir une position de destination pour le joueur
    public Vector2 destination;

    void Start()
    {
        // Chercher le joueur et stocker sa référence dans la variable "player"
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            StartCoroutine(TeleportPlayer());
        }


    }

    IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(0);

        if (player != null && player.activeSelf)
        {
            player.transform.position = new Vector3(destination.x, destination.y, 0);
            player.GetComponent<PlayerController>().transform.position = player.transform.position;
        }
    }
}


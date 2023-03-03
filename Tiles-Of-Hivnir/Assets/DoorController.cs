using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform destination;

    public bool isOut;
    public float distance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        if (isOut == false)
        {
            destination = GameObject.FindGameObjectWithTag("doordunout").GetComponent<Transform>();
        }
        else 
        {
            destination = GameObject.FindGameObjectWithTag("doordun").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2 (destination.position.x, destination.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

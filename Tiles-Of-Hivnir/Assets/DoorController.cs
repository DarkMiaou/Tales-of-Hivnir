using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform destination;

    public bool isOut = true;
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

    public void usedoor(Collider2D other)
    {
        Debug.Log("space pressed");
        other.transform.position = new Vector2 (destination.position.x, destination.position.y);
        isOut = !isOut;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorboss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene("BossMap");
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using TalesofHivnir;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Healthbar healthbarmonster;
    
    private Transform player_;
    private Transform mob_;
    private float x;
    private float y;

    public bool isinside = false;

    public GameObject gamefinishUI;

    public void TakeDamage()
    {
        /*x = mob_.position.x - player_.position.x;
        y = mob_.position.y - player_.position.y;
        if (Math.Abs(x)>= 0 && Math.Abs(x) <= 1 && Math.Abs(y)>= 0 && Math.Abs(y) <= 1 )
        {
            currenthealth -= damage;
            healthbar.SetHealth(currenthealth);
        }
        else
        {
            healthbar.SetHealth(currenthealth);
        }*/
        if (isinside == true)
        {  
            SaveData.instance.monstercurrenthealth -= (int)SaveData.instance.damage;
            Debug.Log("Attaque réalisé");
        }

        if (SaveData.instance.monstercurrenthealth <= 0)
        {
            GameFinish();
        }
    }
    
    private void Start()
    {
      healthbarmonster.SetMaxHealth(SaveData.instance.monstermaxhealth);
     healthbarmonster.SetHealth(SaveData.instance.monstercurrenthealth);
        isinside = false;

    }

    private void Update()
    {
      healthbarmonster.SetHealth(SaveData.instance.monstercurrenthealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player 1")
        {
            isinside = true;
            Debug.Log("detect");
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player 1")
        {
            isinside = false;
            Debug.Log("out");
            
        }
    }

    public void GameFinish()
    {
        
        gamefinishUI.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene("Map");
    }
    
    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

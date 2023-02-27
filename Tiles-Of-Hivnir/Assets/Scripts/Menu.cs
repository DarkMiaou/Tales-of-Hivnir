using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string level_to_load;        
    
    public void Start_Game()
    {
        SceneManager.LoadScene(level_to_load);
    }

    public void Start_Tuto() 
    {
        SceneManager.LoadScene("Test");
        //il faudra changer "Test" si on change le nom de la scene
    }

    public void Quit()
    {
        Application.Quit();
    }
}
    
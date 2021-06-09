using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    //Loads the level
    public void newGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //Exits start menu and quits the game (only works on the compiled version of the game)
    public void Quit()
    {
        Application.Quit(); 
    }

    //This sets the cursor lock state to unlocked, the cursor starts in an unlocked state so it can navigate the menu
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}

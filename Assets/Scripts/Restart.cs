using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class is used for the restart button, OnClick event
public class Restart : MonoBehaviour
{
    //Sends the player back to the start Menu
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

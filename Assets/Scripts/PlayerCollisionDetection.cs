using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class describes some simple collision detection for the player
public class PlayerCollisionDetection : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < 1) //If the player falls below this y coordinate, the level restarts
        {
            SceneManager.LoadScene(1);
        }

    }

    void OnCollisionEnter(Collision mycol)
    {
        if(mycol.gameObject.tag == "Enemy" || mycol.gameObject.tag == "EnemyBoss") //If the player touches an enemy the level restarts
        {
            SceneManager.LoadScene(1);
        }
    }

}

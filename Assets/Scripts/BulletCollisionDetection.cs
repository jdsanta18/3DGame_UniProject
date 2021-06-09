using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple collision detection for the player's bullets
public class BulletCollisionDetection : MonoBehaviour
{

    void OnCollisionEnter(Collision mycol)
    {
        
        
        //Detects collision with Wall and destroys bullet if collision happens
        if (mycol.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        //Detects collision with an object tagged as enemy, and destroys this object, while also increasing the killCount variable
        if (mycol.gameObject.tag == "Enemy")
        {
            Destroy(mycol.gameObject);
            GameObject.Find("Player").GetComponent<Shooting>().killCount++;
        }
    }
}

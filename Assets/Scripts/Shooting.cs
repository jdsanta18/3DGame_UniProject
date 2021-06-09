using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for controlling the player's shooting mechanic, including its HUD elements such as number of bullets
//it also counts the number of kills the player has
public class Shooting : MonoBehaviour
{
    public Rigidbody projectile; //gets a projectile variable as a Rigidbody object
    public Transform spawnPoint; //This object corresponds to the bullet's spawnpoint
    public Camera targetCamera; //The camera which aims the projectile

    private int currentBullets = 0; //Current ammo the player is holding
    public int totalBullets = 6; //Maximum ammo the player can hold

    [HideInInspector]public int killCount = 0; //KillCount variable counts the number of lesser enemies(non-boss) killed, it will be displayed
                                               //in the end screen

    public float speed = 20.0f; //Speed of the bullet
    public float projectileVanishTime; //Amount of time the bullet instance remains on the scene
    
    // Update is called once per frame
    void Update()
    {
        //If the fire button is pressed and the player has bullets remaining, a projectile instance is fired
        if(Input.GetButtonDown("Fire1") && currentBullets > 0)
        {
            Rigidbody projectileInstance; //Creates a projectile instance which is instantiated from the spawnpoint position
            projectileInstance = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as Rigidbody; 
            currentBullets--;//Decreases the number of bullets by one, each time an instance is fired
            projectileInstance.velocity = targetCamera.transform.forward * speed; //Describes the speed and direction(aim) the projectile instance takes
                                                                                  //The projectile moves along its z axis; forward: vector(0,0,1)

            Destroy(projectileInstance.gameObject, projectileVanishTime); //Destroys the projectile instance, after a certain time(projectileVanishTime)
        }
        
    }

    //OnTrigger effect
    void OnTriggerEnter(Collider mycol)
    {
        if(mycol.gameObject.tag == "AmmoPickup")
        {
            currentBullets = totalBullets;
            mycol.gameObject.SetActive(false);
            
        }

    }


    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 50), "Ammo: " + currentBullets + " /  " + totalBullets);
    }
}

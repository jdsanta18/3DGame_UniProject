using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class describes the Enemy type 2(capable of aiming and firing at the player, but immobile), it will be added as a component to a bullet spawnpoint of an enemy unit
public class EnemyType2 : MonoBehaviour
{
    public GameObject projectile;

    public float fireRate; //This public float stores the fire rate value
    private float nextFire; //This private float stores a future time value in which a projectile is instantiated

    // Start is called before the first frame update
    void Start()
    { 
        nextFire = Time.time; //The variable is initialized as the current time
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire) //If the current time is higher than the nextFire time, a projectile is fired
        {
            Instantiate(projectile, transform.position, transform.rotation); //Instantiates a projectile game Object in the current gameObject's position and rotation;
            nextFire = Time.time + fireRate; //The nextFire variable stores the time for the future shot(the current time + the firerate value)
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class respawns one AmmoPickup, after it is deactivated, with a cooldown
public class AmmoPickupRespawning : MonoBehaviour
{
    public GameObject respawnableAmmoPickup; //Ammo Pickup game object
    public float ammoRespawnCooldown = 6f; //Time between each respawn
    private float nextAmmoRespawn; //Time value of the next respawn
    

    // Start is called before the first frame update
    void Start()
    {
        nextAmmoRespawn = Time.time; //this variable starts at the current time
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAmmoRespawn) //If the current time is value is above the nextAmmoRespawn time value, activates the ammo pickup again
        {
            respawnableAmmoPickup.SetActive(true);
            nextAmmoRespawn = Time.time + ammoRespawnCooldown; //nextAmmoRespawn increases by adding a cooldown each time the current time value is the same as it
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the player's body Rotation in first Person mode, since the player has to face forward along its z axis to aim properly
public class FirstPersonBodyRotation : MonoBehaviour
{
    public Transform player;
    public GameObject targetCamera;


    // Update is called once per frame
    private void Update()
    {
        //This will rotate the player object so it faces the same direction as the target camera(will help with shooting)
        player.transform.rotation = Quaternion.Euler(targetCamera.GetComponent<FirstPersonMouseLook>().currentXRotation,  targetCamera.GetComponent<FirstPersonMouseLook>().currentYRotation, 0); //Gets the current rotation values of the Mouse Look Component and rotates the player
    }
}

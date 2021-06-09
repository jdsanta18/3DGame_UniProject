using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject bossObject;
    public Transform teleportPoint;
    private bool isTeleported;

    private void Start()
    {
        playerObject = GameObject.Find("Player"); //Creates a player object
        bossObject = GameObject.Find("Boss"); //Creates a boss object

        bossObject.gameObject.SetActive(false); //Initially the boss game object is deactivated (It is activated when the player goes through this portal)
    }

    //Detects if player has touched the portal's collider
    private void OnTriggerEnter(Collider mycol)
    {
        if (mycol.gameObject.tag == "Player") //If an object with the "Player" tag, triggers the portal, it first disables the character controller component, which overrides, the transform component,not allowing the player's position to be transformed
        {
            playerObject.GetComponent<CharacterController>().enabled = false;
            playerObject.transform.position = teleportPoint.position; //The player object is teleported to the "Boss Stage"
            playerObject.GetComponent<CharacterController>().enabled = true; //The character controller is enabled again so the player can move
            bossObject.gameObject.SetActive(true); //The boss game object is activated, it "summons" the boss
        }
    }
}

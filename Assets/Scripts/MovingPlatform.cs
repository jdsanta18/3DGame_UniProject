using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //These public variables store the coordinates in which the platform moves between
    public float startXPos;
    public float finishXPos;
    public float startYPos;
    public float finishYPos;
    public float startZPos;
    public float finishZPos;

    //This variable changes the platform's moving speed
    public float speedMultiplier; 
    
    public GameObject player; //Player object

    //These vectors store the starting and finish point
    Vector3 startPoint;
    Vector3 finishPoint;

    // Start is called before the first frame update
    void Start()
    {

        startPoint = new Vector3(startXPos, startYPos, startZPos);
        finishPoint = new Vector3(finishXPos, finishYPos, finishZPos);
    }

    // Update is called once per frame
    void Update()
    {
        //The platform's movement is done by interpolating the two vectors, with the interpolant t constantly changing values (between 0 and 1) due to a PingPong function
        transform.position = Vector3.Lerp(startPoint, finishPoint, Mathf.PingPong(speedMultiplier * Time.time, 1));

        //If F key is pressed and the player object is a child of the platform object, the player stands still("grabs the platform")
        if (Input.GetKeyDown(KeyCode.F) == true && player.transform.parent == gameObject.transform)
        {
            player.GetComponent<PlayerController>().enabled = !player.GetComponent<PlayerController>().enabled; //Player Controller has to be disabled to stop it from overriding transformations
        }

    }
    //turns the collider into a child of the platform(player is the child of the platform), if the player is a child of the platform and PlayerController is disabled, it will be transformed the same way as the platform
    void OnTriggerEnter(Collider mycol)
    {
        mycol.transform.parent = gameObject.transform;

       
    }
    //removes the parent(platform) from the collider(player)
    void OnTriggerExit(Collider mycol)
    {
        mycol.transform.parent = null;
    }
}

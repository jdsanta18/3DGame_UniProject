using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the camera change mechanic(by pressing C the player can enter "First Person Aim mode"
public class ChangeCamera : MonoBehaviour
{
    private CharacterController controller;
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;
    public Transform pivot;
    private bool cameraSwitch;
    

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>(); //Creates an instance of the controller object
        pivot.transform.position = gameObject.transform.position; //Sets the pivot's position to the player's position
        pivot.transform.parent = gameObject.transform; //Sets the player as parent of the pivot
        cameraSwitch = false; //Initializes the cameraSwitch variable as false
        firstPersonCamera.gameObject.SetActive(cameraSwitch); //Initializes the First person camera mode as inactive(cameraSwitch is false)
        gameObject.GetComponent<Shooting>().enabled = false; //Shooting starts disabled, because it can only be done while on first person
        gameObject.GetComponent<PlayerController>().enabled = true; //The player Controller starts enabled to allow movement (it is disabled in first person)
    }

    // Update is called once per frame
    void Update()
    {   //  If the player presses C the Camera changes
        if (Input.GetKeyDown(KeyCode.C ) && controller.isGrounded)  //Camera can only be changed if the player object is touching the ground
        {
            cameraSwitch = !cameraSwitch; //Switches the cameraSwitch bool variable to the opposite value
            
            //Changes the pivot back to its original parent(the MainCamera)
            if(cameraSwitch == true)
            {
                pivot.transform.position = thirdPersonCamera.transform.position;
                pivot.transform.parent = thirdPersonCamera.transform;
            }
            else
            {
                pivot.transform.position = gameObject.transform.position;
                pivot.transform.parent = gameObject.transform;
            }

            firstPersonCamera.gameObject.SetActive(cameraSwitch); //First Person Camera is activated/deactivated depending on the value of cameraSwitch
            gameObject.GetComponent<PlayerController>().enabled = !gameObject.GetComponent<PlayerController>().enabled; //Player Controller is activated/deactivated
            gameObject.GetComponent<Shooting>().enabled = !gameObject.GetComponent<Shooting>().enabled; //Shooting component is activated/deactivated
            thirdPersonCamera.gameObject.SetActive(!cameraSwitch);//Third Person Camera is activated/deactivated depending on the value of cameraSwitch
        }
    }
}

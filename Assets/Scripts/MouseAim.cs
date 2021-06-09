using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the Main Camera Controller(the class name couldn't be refactored, this class was named for a feature that was scrapped)
public class MouseAim : MonoBehaviour
{
    public Transform target; //The object the Camera will follow
    private Vector3 offset; //Private vector that stores the offset distance between the target(player) and the camera
    public float mouseSensivity = 2.0f; //Variable that stores the mouse sensivity value
    

    public Transform pivot; //The pivot object will be set as a child to the target(player) object (See the ChangeCamera class)

    // Start is called before the first frame update
    private void Start()
    {
        offset = target.position - transform.position; 
        

        Cursor.lockState = CursorLockMode.Locked; //The cursor is locked to create a more realistic mouse look
    }

    // Update is called once per frame
    private void LateUpdate()
    { 
        //Gets the X position of the mouse and rotates the target(player) along the y axis
        float horizontal = Input.GetAxis("Mouse X") * mouseSensivity; 
        target.Rotate(0, horizontal, 0);
       
        //Gets the Y position of the mouse and rotates the pivot along the x axis
        float vertical = Input.GetAxis("Mouse Y") * mouseSensivity;
        target.Rotate(-vertical, 0, 0);


        float desiredYAngle = target.eulerAngles.y; //this variable stores the target's current rotation along the y axis
        float desiredXAngle = pivot.eulerAngles.x; //This variable stores the pivot's current rotation along the x axis
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0); //Stores a  Quaternion according to the current angle variables stored
        transform.position = target.position - (rotation * offset); //Multiplying a quaternion(rotation) and a Vector(offset) will rotate that vector relatively to the origin(0, 0, 0)
                                                                    //The camera position is determined by subtracting the player's position by the rotated vector

        if(transform.position.y < target.position.y) //If the camera is lower in the y axis than the player, it resets to a higher position (For better camera control)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.3f, transform.position.z);
        }

        //The camera keeps facing the target
        transform.LookAt(target);

    }
}

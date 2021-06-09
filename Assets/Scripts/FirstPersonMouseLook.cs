using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This class is a controller for the First person camera
public class FirstPersonMouseLook : MonoBehaviour
{
    public float FP_Sensivity = 2.0f; //This variable stores mouse sensivity for the this camera
    private Vector2 rotation = new Vector2(0, 0); //This vector stores a rotation along the x and y axes
    public float currentXRotation; //This float stores the current rotation angle along the x axis
    public float currentYRotation; //This float stores the current rotation angle along the y axis



    // Update is called once per frame
    void LateUpdate()
    {
        rotation.y += Input.GetAxis("Mouse X"); //Gets the X position of the mouse and stores it in the y axis of the rotation vector
        rotation.x += -Input.GetAxis("Mouse Y"); //Gets the Y position of the mouse and stores it in the x axis of the rotation vector

        currentXRotation = rotation.x; //For use in FirstPersonBodyRotation class (here for readability)
        currentYRotation = rotation.y; //For use in FirstPersonBodyRotation class (here for readability)
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0); //Applies the rotation to the camera object according to the values stored in the rotation vector
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This class controls the player movement while on the third person camera
//It also checks if the player has reached the End of the Pre-Boss Stage and outputs a message
public class PlayerController : MonoBehaviour
{
    private GameObject[] enemies;

    private CharacterController controller;
    public float speed = 5.0f; //this variable determines the movement speed while on the ground
    public float jumpSpeed = 10.0f; //this variable determines the jump speed
    public float gravityMultiplier = 5.0f; //this variable allows manipulation of the gravity

    Vector3 movement = Vector3.zero; //Movement vector 

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>(); //initializing an object from the CharacterController class
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");//Initializing an enemy object
    }

    // Update is called once per frame
    private void Update()
    {
        

        float yBuffer = movement.y;
        movement = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        movement = movement.normalized * speed;
        movement.y = yBuffer;

        //Jumping Controls
        if(Input.GetButton("Jump") && controller.isGrounded == true)
        {
            movement.y = jumpSpeed;
        }

        //Checks if gravity can be applied (if player is not grounded), and applies it
        if (controller.isGrounded == false)
        {
            movement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }

        //Applies movement to the character, this movement is described by the movement vector mentioned above
        controller.Move(movement * Time.deltaTime);

        //Accessing startmenu while mid-game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
  
    }
    //Checks for collisions
    private void OnCollisionEnter(Collision mycol)
    {   //if the player object collides with the "StageEnd" tagged object, it destroys this object and all the objects tagged as "enemy"
        if(mycol.gameObject.tag == "StageEnd")
        {
            Destroy(mycol.gameObject);

            foreach(GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }

    


}

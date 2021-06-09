using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This classes describes the behavious an Enemy bullet when instantiated, and also is responsible for the collision detection
public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f; //Speed of the bullet
    public float projectileVanishTime; //Time it takes for a projectile instance to be deleted from the scene
    Rigidbody rb; //Creating a rigidbody
    GameObject player; //Instantiating a player object
    

    Vector3 moveDirection; //The vector that represents the direction a projectile takes when it's instantiated

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); //Initializing the rigidbody object
        player = GameObject.Find("Player"); //initializing the object
        moveDirection = (player.transform.position - transform.position).normalized * speed; //Determines the Direction and speed the bullet will take when instantiated
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z); //Applies the movement to the rigidBody according to the vector calculated above
    }

    
    void Update()
    {
        Destroy(gameObject, projectileVanishTime); //Destroys an instance after a certain time
    }

    //Some collision detection
    void OnCollisionEnter(Collision mycol)
    {
       if(mycol.gameObject.tag == "Wall") //If it collides with a wall, the bullet is destroyed
        {
            Destroy(gameObject);
        }
       if(mycol.gameObject.tag == "Player")//If it collides with the player object(object tagged as "player") it loads the level again
        {
            SceneManager.LoadScene(1);
        }
    }
}

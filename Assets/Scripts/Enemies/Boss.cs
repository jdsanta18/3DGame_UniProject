using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This class describes the Boss AI, and checks for the winning condition
public class Boss : MonoBehaviour
{
    GameObject player; //the player object
    
    public float moveSpeed = 5f; //This variable stores the boss's movement speed
    public int maxHealth = 100; //This variable stores the boss's max health value
    private int currentHealth; //this variable stores the boss's current health
    public int playerBulletDamage = 10; //This variable determines how much damage a player bullet does to the boss
    public Slider healthBar; //Health bar Slider Object

    private GameObject[] turrets; //This array stores all turret GameObjects

    public Text winText; //This object allows us to manipulate the text displayed in the end

    // Start is called before the first frame update
    private void Start()
    {
        winText.text = ""; //Initializing the text component in the winText object

        currentHealth = maxHealth; //Current Health starts with the same value as max health

        player = GameObject.Find("Player"); //Initializes the player object

        turrets = GameObject.FindGameObjectsWithTag("Turret"); //Initializes the turret Game objects in the turrets array
        foreach (GameObject turret in turrets)
        {
            turret.gameObject.SetActive(false);         //Sets all turret objects to start inactive
        }
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * 4.5f, ForceMode.Acceleration); //Alters the boss's rigidBody component by changing its gravity force

        transform.LookAt(player.transform); //The boss rotates to face the player
        transform.position += transform.forward * moveSpeed * Time.deltaTime; //The boss moves forward on its z axis, moveSpeed determines its speed

        if (currentHealth <= 50) //Boss enters "Angry Mode" and spawns turrets
        {
            foreach (GameObject turret in turrets)
            {
                turret.gameObject.SetActive(true);
            }
        }
        if(currentHealth <= 0) //If boss dies, the winning message is displayed
        {
            Destroy(gameObject); //The boss game object is destroyed
            foreach (GameObject turret in turrets) //The turret objects are destroyed
            {
                turret.gameObject.SetActive(false);
            }

            //Displays the winning message(with the time taken to complete the level and the killCount)
            winText.text = "You've beaten the game, it took you " + Time.timeSinceLevelLoad + " seconds \nYou also killed: " + player.GetComponent<Shooting>().killCount + " lesser enemies";
            //Activates the Restart Button game object
            winText.transform.GetChild(0).gameObject.SetActive(true);
            //Unlocks the cursor so the player can click restart
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //If the boss collides with a player bullet, damage is dealt
    private void OnTriggerEnter(Collider mycol)
    {
        if(mycol.GetComponent<Rigidbody>().tag == "Bullet")
        {
            Physics.IgnoreCollision(mycol.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
            currentHealth -= playerBulletDamage;
            healthBar.value = currentHealth;
        }
    }
}

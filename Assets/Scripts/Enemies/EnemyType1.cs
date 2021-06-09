using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : MonoBehaviour
{
    public GameObject countControl;
    

    public float startXPos;
    public float finishXPos;
    public float startYPos;
    public float finishYPos;
    public float startZPos;
    public float finishZPos;
    public float speedMultiplier;
    
    float heading;
    Rigidbody rb;

    Vector3 startPoint;
    Vector3 finishPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPoint = new Vector3(startXPos, startYPos, startZPos);
        finishPoint = new Vector3(finishXPos, finishYPos, finishZPos);
    }

    // Update is called once per frame
    void Update()
    {
        //
        transform.position = Vector3.Lerp(startPoint, finishPoint, Mathf.PingPong(speedMultiplier * Time.time, 1));

        //Rotates the enemy character every frame  around the y axis
        transform.Rotate(0, 2, 0);

        
    }

    

}

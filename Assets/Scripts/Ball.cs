using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // 3 collision states are, OnColissionEnter(), OnCollisionStay(), OnCollisionExit()
    // to make a collider a pass-through collider, set the collider to be a trigger

    private void OnCollisionEnter(Collision collision)
    {
        // Check for colission
        // Debug.Log("Ball collided with " + collision.gameObject.name);

        // Filter out the object of interest
        if (collision.gameObject.CompareTag("Pin"))
        {
            //Debug.Log("Collided with a pin");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Ball has entered the pit");
        
        manager.SetNextThrow();

        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // reference to player speed.
    public float speed = 5.0f;
    // reference to rigid body component applied to the player.
    private Rigidbody playerRb;

    void Start()
    {
        // initializes rigidbody component at start.
        playerRb = GetComponent<Rigidbody>();       
    }

    
    void Update()
    {
        // gets the player vertical input.
        float forwardInput = Input.GetAxis("Vertical");
        // moves the player with AddForce method based on forwardInput.
        playerRb.AddForce(Vector3.forward * speed * forwardInput);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // reference to player speed.
    public float speed = 5.0f;
    // reference to rigid body component applied to the player.
    private Rigidbody playerRb;
    // reference to focalPoint.
    private GameObject focalPoint;

    // reference boolean to check powerUp.
    public bool hasPowerUp = false;

    void Start()
    {
        // initializes rigidbody component at start.
        playerRb = GetComponent<Rigidbody>();
        // inititalizes focal point check at start.
        focalPoint = GameObject.Find("Focal Point");
    }

    
    void Update()
    {
        // gets the player vertical input.
        float forwardInput = Input.GetAxis("Vertical");
        // moves the player with AddForce method based on forwardInput.
        //playerRb.AddForce(Vector3.forward * speed * forwardInput);

        // moves the player in the direction of focal point with AddForce method based on forwardInput. 
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        // checks if this gameobject collides with other gameobject with a compareTag.
        if (other.CompareTag("PowerUp"))
        {
            // changes the bool to true when player runs into the powerUp.
            hasPowerUp = true;
            // destroys the other gameobject that collides with this one.
            Destroy(other.gameObject);
        }
    }
}

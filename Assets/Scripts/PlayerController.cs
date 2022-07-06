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
    // reference to force of interaction.
    private float powerUpStrength = 15.0f;
    // reference boolean to check powerUp.
    public bool hasPowerUp = false;

    // reference to powerUpIndicator gamobject.
    public GameObject powerUpIndicator;
    // bool check if the player is grounded or not.
    bool isGrounded = true;


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

        // sets the powerUpIndicator position to the player's position.
        //powerUpIndicator.transform.position = transform.position;
        // offsets the indicator by the value of a new vector on Z-axis.
        powerUpIndicator.transform.position = transform.position + new Vector3(0, 1, 0);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //moves the player in upward direction with AddForce method.
            playerRb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            // checks if the player is in the air.
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // checks if this gameobject collides with other gameobject with a compareTag.
        if (other.CompareTag("PowerUp"))
        {
            // changes the bool to true when player runs into the powerUp.
            hasPowerUp = true;
            // activates the powerUpIndicator when powerUp is picked up.
            powerUpIndicator.gameObject.SetActive(true);
            // destroys the other gameobject that collides with this one.
            Destroy(other.gameObject);
            // starts the coroutine.
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        // waits for 7secs and disables the powerUp.
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        // deactivates powerUpIndicator after a set time.
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checks if player collides with enemy and hasPowerUp turned on
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // creates a variable to hold the rigidbody component of enemy gameobject.
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // creates a variable to get the direction away from player.
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Collided with: " + collision.gameObject.name + "with power set to" + hasPowerUp);

            // adds immediate force to the rigidbody in the direction away from the player.
            //enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            // checks if player is grounded when it hits the ground.
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(collision.gameObject, 1);
        }
        
    }

}

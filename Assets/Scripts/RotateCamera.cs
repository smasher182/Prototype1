using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    // reference to camera rotation speed.
    public float rotationSpeed;
   
    void Update()
    {
        // gets the player horizontal input.
        float horizontalInput = Input.GetAxis("Horizontal");

        // rotates the camera by a degree everytime the frame updates.
        // transform.Rotate(Vector3.up, 1); 

        // rotates the camera based on horizontal input and rotation speed over time.
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}

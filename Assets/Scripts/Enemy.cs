using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // reference to enemy speed.
    public float speed = 3.0f;
    // reference to enemy rigidbody.
    private Rigidbody enemyRb;
    // reference to player.
    private GameObject player;

    void Start()
    {
        // initializes rigidbody on enemy at start.
        enemyRb = GetComponent<Rigidbody>();
        // finds the player reference at start.
        player = GameObject.Find("Player");
        
    }

    
    void Update()
    {
        Vector3 LookDirection = (player.transform.position - transform.position).normalized;

       // moves enemy towards the direction of player.
       // multiplies speed to the difference between player and enemy position, hence the parenthesis.
       // normalizes enemy speed irrespective of distance between player and enemy.
       // enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

        enemyRb.AddForce(LookDirection * speed);


    }
}

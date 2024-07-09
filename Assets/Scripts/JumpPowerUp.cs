using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float gravityForce = 2.0f;
    public float jumpForce = 10.0f;

    void Start()
    {
        // modify the global gravity at the start of the game
        Physics.gravity *= gravityForce;
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the colliding object has the tag player 
        if (other.CompareTag("Player"))
        {
            // get the FPSInput component from the player object 
            FPSInput player = other.GetComponent<FPSInput>();
            if (player != null)
            {
                // set the player's grounded state to false and apply the jump force 
                player.isGrounded = false;
                player.Jump(jumpForce);
            }
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    private CharacterController charController;
    public float gravity = -9.8f;
    public float jumpPower = 5.0f;
    public bool isGrounded; // flag to check if the player is on the ground 
    public bool isJumping; // flag to check if the play is currently jumping

    private Vector3 velocity;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        isGrounded = true; // player starts on ground
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * movementSpeed;
        float deltaZ = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, movementSpeed);

        // check if the player is ground and the jump button is pressed 
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // apply jump force and set grounded and jumping flags 
                velocity.y = jumpPower;
                isGrounded = false;
                isJumping = true;
            }
        }
        else
        {
            // apply gravity to the player's movement 
            velocity.y += gravity * Time.deltaTime;
        }

        // set the y-component of the movement vector to the current velocity 
        movement.y = velocity.y;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        charController.Move(movement);

        // check if the player has landed back on the ground
        if (charController.isGrounded)
        {
            velocity.y = 0; // reset the vertical velocity
            isGrounded = true; // set grounded flag to true
            isJumping = false; // set jumping flag to false
        }
    }

    public void Jump(float jumpForce)
    {
        // apply the jump force if the player is not grounded 
        if (!isGrounded)
        {
            velocity.y = jumpForce;
            charController.Move(velocity * Time.deltaTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{

    public float movementSpeed = 2.0f;

    // creating variable to reference CharacterController
    private CharacterController charController;

    public float gravity = -9.8f;


    // Start is called before the first frame update
    void Start()
    {
        // chnace this can be null, so we need to initalize at start
        // access other components attacehd to the same object
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * movementSpeed;
        float deltaZ = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, movementSpeed);


        // Debug.Log(movement);
        // use the gravity instead of 0
        movement.y = gravity;
        // limit diagonal movement to the same speed as movment along an axis
        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        // transform the movement vector from local to global
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        // tell the charactercontroller to move with the vector
        charController.Move(movement);
    }
}
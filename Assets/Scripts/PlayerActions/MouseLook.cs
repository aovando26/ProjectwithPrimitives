using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxis 
    { 
        MouseXAndY = 0,
        MouseY = 1,
        MouseX = 2,
    }

    // view enum in editor 
    public RotationAxis axes = RotationAxis.MouseXAndY;
    public float sensitivityHor = 1.0f; 
    public float sensitivityVert = 1.0f;

    public float mininumVert = -45.0f;
    public float maximumVert = 45.0f; 

    private float verticalRot = 0.0f;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

        void Update()
    {
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxis.MouseY)
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;

            verticalRot = Mathf.Clamp(verticalRot, mininumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;

            verticalRot = Mathf.Clamp(verticalRot, mininumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}

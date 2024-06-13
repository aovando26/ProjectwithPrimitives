using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float speedMovement = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // can use Vector3.forwward for (0,0,1) then scaled with speedMovement  * Time.deltaTime
        transform.Translate(Vector3.back * speedMovement * Time.deltaTime);
    }
}

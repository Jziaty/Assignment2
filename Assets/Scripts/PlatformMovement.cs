using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;

    public string currentState;
    public float resetTime;

    //private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        resetTime = 14f;
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, 0.1f);
        //rb.AddRelativeForce(Vector3.forward);
               
    }

    void ChangeTarget()
    {
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}

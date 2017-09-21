using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Range(0f, 200f)]
    public float Force;

    [Range(0f, 500f)]
    public float JumpForce;

    public Rigidbody rb;

    public bool isGrounded;

	// Use this for initialization
	void Start () {
        Force = 100f;
        JumpForce = 200f;
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }
            
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        //transform.position += new Vector3(vertical, 0, -horizontal) * MovementSpeed;
        rb.AddRelativeForce(vertical * Force, 0, 0);

        rb.AddTorque(0, horizontal * Force, 0);

        if (isGrounded == true)
        {
            Jump();
        }
        
    }

    void Jump()
    {
        float jump = Input.GetAxisRaw("Jump");

        rb.AddRelativeForce(0, jump * JumpForce, 0);
        //isGrounded = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public int Movementspeed;
    public Rigidbody rb;

    public Transform target1;
    public Transform target2;
    public Transform target3;

    private Transform InitPos;

    private void Start()
    {
        InitPos = transform;
        Movementspeed = 1;

        StartCoroutine(Movement(target1));
        StartCoroutine(Movement(target2));
        StartCoroutine(Movement(target3));
        StartCoroutine(Movement(InitPos));
    }

    IEnumerator Movement(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) /* Movementspeed*/ > 0.0f)
        {
            //Hier een add force gaan gebruiken ipv lerp waarschijnlijk helpt dat met collision
            transform.position = Vector3.Lerp(transform.position, target.position, 1f * Time.deltaTime);
            //transform.position = rb.AddForce(target.position - transform.position);
            

            yield return null;
        }
    }
}

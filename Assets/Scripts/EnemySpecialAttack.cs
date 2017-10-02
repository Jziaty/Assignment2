using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialAttack : MonoBehaviour {

    public EnemyStats EStats;

    public GameObject InverseVolume;
    public GameObject Player;

    private CapsuleCollider capCol;
    public bool GravityInversed;

    private float elapsedtime;
    private Rigidbody rb;
    private bool InVolume = false;



    void OnEnable()
    {
        EnemyMovement.OnReach += InverseGravity;
        
    }

    void OnDisable()
    {
        EnemyMovement.OnReach -= InverseGravity;
    }

    // Use this for initialization
    void Start () {
        InverseVolume = GameObject.FindGameObjectWithTag("InvVolume");
        Player = GameObject.FindGameObjectWithTag("Player");
        capCol = GetComponent<CapsuleCollider>();
        rb = Player.GetComponent<Rigidbody>();
        
	}

    void Update()
    {
        if (GravityInversed == true)
        {
            elapsedtime += Time.deltaTime;
            if (elapsedtime > EStats.SpecialMoveDuration)
            {
                GravityInversed = false;
                rb.useGravity = true;
            }
            Debug.Log(elapsedtime);
        }
    }

    private void FixedUpdate()
    {
        if (GravityInversed)
        {
            rb.AddForce(0f, 9.81f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.transform.name + " found in collider.");
        if (other.transform.tag == "Player")
        {

            InVolume = true;
        }
    }

    void InverseGravity()
    {
        EStats.Count = 0;
        
        capCol.radius = EStats.targetDistance;
        
        if (InVolume)
        {
            rb.useGravity = false;
            GravityInversed = true;

        }
        else
        {
            Debug.LogError("In Volume not becoming true");
        }
        
    }
}
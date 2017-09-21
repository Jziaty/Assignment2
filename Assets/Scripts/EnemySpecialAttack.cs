using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialAttack : MonoBehaviour {

    public GameObject InvVolume;
    public GameObject Player;

    private CapsuleCollider capCol;
    private float grav;

	// Use this for initialization
	void Start () {
        InvVolume = GameObject.FindGameObjectWithTag("InvVolume");
        Player = GameObject.FindGameObjectWithTag("Player");

        InvVolume.SetActive(false);
	}

    public void SpecialAttack(float Distance)
    {
        InvVolume.SetActive(true);
        capCol = GetComponent<CapsuleCollider>();
        capCol.radius = Distance;

        InverseGravity();
    }
    
    void InverseGravity()
    {
        Physics.gravity = Physics.gravity * -1;
        Debug.Log(Physics.gravity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialAttack : MonoBehaviour {

    private float grav;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpecialAttack()
    {
        //Use a Capsule collider and within this collider, I need to change the gravity.
        grav = Physics.gravity.y;
        //Multiply grav by -1 for the duration given in the SO.
    }
}

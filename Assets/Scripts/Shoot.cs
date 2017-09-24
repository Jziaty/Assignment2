using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Rigidbody bullet;
    public Transform Bullets;
    public float speed = 20;

    public int Bulletcount = 0;
    
	
	// Update is called once per frame
	void Update () {
        Bulletcount = GameObject.FindGameObjectsWithTag("Bullet").Length;
		if (Input.GetButtonDown("Fire1"))
        {
            if (Bulletcount <= 2)
            {
                Rigidbody instantiatedProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                
                instantiatedProjectile.transform.parent = Bullets;
                Destroy(instantiatedProjectile.gameObject, 2.5f);
            }
            
        }
	}
}

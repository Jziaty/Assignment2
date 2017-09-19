using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public EnemyStats EnemyStatsInstance;
    public Transform target;
    

	void Start () {
        EnemyStatsInstance.Count = 0;
        StartCoroutine(Movement(target));
	}

    void FixedUpdate()
    {
        if (EnemyStatsInstance.Count >= 3)
        {
            InverseGravity();
        }
    }

    IEnumerator Movement (Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) * EnemyStatsInstance.MovementSpeed > EnemyStatsInstance.targetDistance)
        {
            //Hier een add force gaan gebruiken ipv lerp waarschijnlijk helpt dat met collision
            transform.position = Vector3.Lerp(transform.position, target.position, EnemyStatsInstance.smoothing * Time.deltaTime);

            
            yield return null;
        }

        EnemyStatsInstance.Count++;
        print("Reached the target.");

        yield return new WaitForSeconds(3f);

        print("Courotine 'Movement' is now finished.");
    }

    public void InverseGravity()
    {
        // Do shit
    }
}

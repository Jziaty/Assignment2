using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public EnemyStats EnemyStatsInstance;
    
    public Transform target;
    
    public int Count;

	void Start () {
        StartCoroutine(Movement(target));
	}
	
	IEnumerator Movement (Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) * EnemyStatsInstance.MovementSpeed > EnemyStatsInstance.targetDistance)
        {
            //Hier een add force gaan gebruiken ipv lerp waarschijnlijk helpt dat met collision
            transform.position = Vector3.Lerp(transform.position, target.position, EnemyStatsInstance.smoothing * Time.deltaTime);

            
            yield return null;
        }

        print("Reached the target.");
        Count++;

        yield return new WaitForSeconds(3f);

        print("Courotine 'Movement' is now finished.");
    }
}

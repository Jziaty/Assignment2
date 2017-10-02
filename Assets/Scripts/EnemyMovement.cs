using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public delegate void targetReached();
    public static event targetReached OnReach;

    public EnemyStats EnemyStatsInstance;
    public EnemySpecialAttack ESP;
    public Transform target;
    

	void Start () {
        EnemyStatsInstance.Count = 0;
        StartCoroutine(Movement(target));
	}

     void Update()
     {
        
     }

    IEnumerator Movement(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) * EnemyStatsInstance.MovementSpeed > EnemyStatsInstance.targetDistance)
        {
            //Hier een add force gaan gebruiken ipv lerp waarschijnlijk helpt dat met collision
            transform.position = Vector3.Lerp(transform.position, target.position, EnemyStatsInstance.smoothing * Time.deltaTime);


            yield return null;
        }

        EnemyStatsInstance.Count++;
        //print("Reached the target.");
        targetIsReached();


        //print("Coroutine 'Movement' is now finished.");


    }

    public void targetIsReached()
    {
        if (EnemyStatsInstance.Count >= 3)
        {
            if(OnReach != null)
            {
                OnReach();
            }
            Debug.Log("There are no functions subscribed to OnReach.");
            
        } else
        {
            //Debug.Log(EnemyStatsInstance.Count);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Destroy(gameObject, 1f);
        }
    }
}

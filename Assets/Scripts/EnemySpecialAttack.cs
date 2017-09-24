using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialAttack : MonoBehaviour {

    public GameObject InvVolume;
    public GameObject Player;
    public GameObject[] Enemies;

    private CapsuleCollider capCol;
    private Rigidbody rbN;
    private float grav;
    private float SpecDur;
    public bool GravityInversed;

    private float elapsedtime;

	// Use this for initialization
	void Start () {
        InvVolume = GameObject.FindGameObjectWithTag("InvVolume");
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        capCol = GetComponent<CapsuleCollider>();

        InvVolume.SetActive(false);
	}

    void Update()
    {
        elapsedtime += Time.deltaTime;
        if (GravityInversed == true)
        {
            CheckDuration(SpecDur);
        }
    }

    public void SpecialAttack(float Distance, float time)
    {
        InvVolume.SetActive(true);
        capCol.radius = Distance;

        InverseGravity(time);
    }
    
    void InverseGravity(float time)
    {
        GravityInversed = true;

        if (Enemies != null)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                rbN = Enemies[i].GetComponent<Rigidbody>();
                rbN.useGravity = false;
            }
        } else
        {
            Debug.Log("No enemies found");
        }        
        
        Debug.Log(Physics.gravity);

        CheckDuration(time);
    }

    void CheckDuration(float Duration)
    {
        SpecDur = Duration;

        
        
        Debug.Log(elapsedtime);

        if (elapsedtime < Duration && GravityInversed)
        {
            Physics.gravity = Physics.gravity * -1;
            GravityInversed = false;
        }
        else if (elapsedtime >= Duration && !GravityInversed)
        {
            Physics.gravity = Physics.gravity * -1;
            for (int i = 0; i < Enemies.Length; i++)
            {
                rbN = Enemies[i].GetComponent<Rigidbody>();
                rbN.useGravity = true;
                //GravityInversed = false;
            }
        }
    }
}
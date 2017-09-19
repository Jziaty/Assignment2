using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject {
    
    [Range(1f, 20f)]
    public float targetDistance = 2.5f;
    [Range(0.5f, 1.5f)]
    public float smoothing = 1f;
    [Range(0f, 2f)]
    public float MovementSpeed = 1f;
    [Range(0f, 10f)]
    public float SpecialMoveDuration = 5f;

    public int Count;
}

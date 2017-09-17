using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public PlayerMovement player;

    [Range(-10.0f, 10.0f)]
    public float offsetX;

    [Range(-10.0f, 10.0f)]
    public float offsetY;


    // Use this for initialization
    void Start()
    {
        offsetX = -7f;
        offsetY = 10f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, 0);
    }
}

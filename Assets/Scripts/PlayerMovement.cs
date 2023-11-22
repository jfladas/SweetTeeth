using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float portDelay = 1f;
    public float portFactor = 5f;
    private Vector3 moveVector = new Vector2(1, 0);
    private Vector3 portVector = new Vector3();
    private Vector3 worldPos = new Vector3();
    private Vector2 mousePos = new Vector2();
    private Vector2 playerPos = new Vector2();
    private Vector2 deltaPos = new Vector2();
    
    // Start is called before the first frame update
    void Start()
    {
        //seconds
        //InvokeRepeating("Teleport", portDelay, portDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        transform.Translate(Vector3.right * Time.deltaTime);
/*
        //calc portVector
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.Set(worldPos.x, worldPos.y);
        playerPos.Set(transform.position.x, transform.position.y);
        deltaPos = mousePos - playerPos;
        deltaPos.Normalize();
        portVector.Set(deltaPos.x, deltaPos.y, 0f);
        //vector player -> circle (direction mouse)
        portVector = portVector * portFactor;
        */
    }

    void Teleport()
    {
        transform.position = transform.position + portVector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, portDelay, portFactor;
    private Vector2 portVector = new Vector2();
    private Vector3 worldPos;
    private Vector2 mousePos, playerPos, deltaPos;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        //seconds between teleport
        portDelay = 1f;
        portFactor = 5f;

    InvokeRepeating("Teleport", portDelay, portDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    public Vector2 calcPortVector(){
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.Set(worldPos.x, worldPos.y);
        playerPos.Set(transform.position.x, transform.position.y);
        deltaPos = mousePos - playerPos;
        deltaPos.Normalize();
        portVector.Set(deltaPos.x, deltaPos.y);
        //vector player -> circle (direction mouse)
        return portVector;
    }

    void Teleport()
    {
        transform.Translate(calcPortVector() * portFactor);
    }

    
}

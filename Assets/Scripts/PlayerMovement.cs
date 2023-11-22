using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, portDelay, portFactor;
    public static Vector2 portVector;
    private Vector3 worldPos; 
    private Quaternion rotPlayer;
    public static Vector2 mousePos, playerPos, deltaPos;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        //seconds between teleport
        portDelay = 1.5f;
        portFactor = 7f;

        rotPlayer.Set(0, 0, 0, 0);

        InvokeRepeating("Teleport", portDelay, portDelay);
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        
        transform.rotation = rotPlayer;

        calcPortVector();
    }

    public void calcPortVector(){
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.Set(worldPos.x, worldPos.y);
        playerPos.Set(transform.position.x, transform.position.y);
        deltaPos = mousePos - playerPos;
        deltaPos.Normalize();
        portVector.Set(deltaPos.x, deltaPos.y);
        portVector = portVector * portFactor;
        //vector player -> circle (direction mouse)
        //return portVector;
    }

    void Teleport()
    {
        transform.Translate(portVector);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        //GetComponent<Rigidbody2D>().angularVelocity = new Vector2(0f, 0f);
    }

    
}

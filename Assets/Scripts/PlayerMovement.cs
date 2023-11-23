using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector2 portVector, mousePos, playerPos, deltaPos;
    private Vector3 worldPos;
    public float moveSpeed, portDelay, portFactor;
    private Quaternion rotPlayer;

    void Start()
    {
        moveSpeed = 4f;

        //seconds between teleport
        portDelay = 1.5f;

        //radius
        portFactor = 10f;
        GameObject.Find("radius").transform.localScale = new Vector2(1,1) * portFactor * 10;

        rotPlayer.Set(0, 0, 0, 0);

        InvokeRepeating("Teleport", portDelay, portDelay);

    }

    void Update()
    {
        //basic movement
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        transform.rotation = rotPlayer;

        calcVectors();
    }

    public void calcVectors(){
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.Set(worldPos.x, worldPos.y);

        playerPos.Set(transform.position.x, transform.position.y);

        deltaPos = mousePos - playerPos;
        deltaPos.Normalize();
        portVector.Set(deltaPos.x, deltaPos.y);
        portVector = portVector * portFactor;
        //vector player -> circle (direction mouse)
    }

    void Teleport()
    {
        transform.Translate(portVector);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }
    
}

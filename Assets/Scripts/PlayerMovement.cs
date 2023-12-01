using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector2 portVector, mousePos, playerPos, deltaPos;
    private Vector3 worldPos;
    public float moveSpeed, portDelay, portFactor;
    private Quaternion rotPlayer;
    public static bool init;

    public AudioSource audio;
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);


        init = false;

        moveSpeed = 5f;

        //seconds between teleport
        portDelay = 1.5f;

        //radius
        portFactor = 10f;
        GameObject.Find("radius").transform.localScale = new Vector2(1,1) * portFactor * 2;

        rotPlayer.Set(0, 0, 0, 0);
    }

    void Update()
    {
        transform.rotation = rotPlayer;
        calcVectors();
        //basic movement
        if (Play.started)
        {
            if(!init){
                init = true;
                InvokeRepeating("Teleport", portDelay, portDelay);
            }
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        } else
        {
            gameObject.GetComponent<AudioSource>().Stop();
            CancelInvoke();
        }
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

    void Init()
    {
        InvokeRepeating("Teleport", portDelay, portDelay);
    }
    void Teleport()
    {
        transform.Translate(portVector);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);

        audio.Play();
    }
    public static void Reset()
    {
        init = false;
    }
}

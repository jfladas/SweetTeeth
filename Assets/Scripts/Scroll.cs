using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //private Vector3 moveVector = new Vector3.left;

    public float moveSpeed;

    void Start()
    {
        //scroll speed
        moveSpeed = 8f;
    }
    
    void Update()
    {
        if(Play.started)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}

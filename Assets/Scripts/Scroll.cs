using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Vector3 moveVector = new Vector2(-1, 0);

    //scroll speed
    public float moveSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveVector * moveSpeed * Time.deltaTime);
    }
}

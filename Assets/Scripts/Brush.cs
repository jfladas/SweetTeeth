using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    private bool up;
    public float moveSpeed;
    void Start()
    {
        up = true;
        moveSpeed = 8f;
    }

    void Update()
    {
        if (Play.started)
        {
            if (transform.position.y > -6f)
            {
                up = false;
            }
            if (transform.position.y < -9f)
            {
                up = true;
            }
            if (up)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }
    }
}

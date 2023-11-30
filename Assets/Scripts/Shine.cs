using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine : MonoBehaviour
{
    private bool grow;
    public float moveSpeed;

    private Vector3 scaleChange;
    void Start()
    {
        grow = true;
        moveSpeed = 12f;
    }

    void Update()
    {
        if (transform.localScale.x > 1.2f)
        {
            grow = false;
        }
        if (transform.localScale.x < 0.7f)
        {
            grow = true;
        }

        if (grow)
        {
            scaleChange = new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime * moveSpeed;
        }
        else
        {
            scaleChange = new Vector3(-0.1f, -0.1f, -0.1f) * Time.deltaTime * moveSpeed;
        }

        transform.localScale += scaleChange;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    bool isHovering = false;
    public float timeToWait = 2.3f;
    float timeLeft;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cursor") && !isHovering && !Play.started)
        {
            timeLeft = timeToWait;
            isHovering = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cursor") && !Play.started)
        {
            isHovering = false;
        }
    }

    void Update()
    {
        if(!Play.started){
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (isHovering)
            {
                transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    Application.Quit();
                }
            }
            else
            {
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }else{
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

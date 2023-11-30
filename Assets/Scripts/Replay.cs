using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Replay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovering = false;
    public float timeToWait = 2.3f;
    float timeLeft;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isHovering && !Play.started)
        {
            gameObject.GetComponent<AudioSource>().Play();
            timeLeft = timeToWait;
            isHovering = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Play.started)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            isHovering = false;
        }
    }

    void Update()
    {
        if (isHovering)
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                isHovering = false;
                GameObject.Find("caries").transform.position = Death.startPosPlayer;
                GameObject.Find("caries").GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GameObject.Find("Main Camera").transform.position = Death.startPosCam;
                Play.LoadGame();
            }
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}

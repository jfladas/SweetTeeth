using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{

    public Sprite spriteW, spriteB;
    private SpriteRenderer sr;
    private Collider player;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = spriteW;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.sprite = spriteB;
        }
    }
    public void Unrot(){
        sr.sprite = spriteW;
    }
}

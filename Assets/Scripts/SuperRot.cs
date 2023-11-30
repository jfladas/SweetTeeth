using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRot : MonoBehaviour
{
    public Color normalCol, superCol;

    private void Start() {
        normalCol = new Color(255f / 255f, 255 / 255f, 255 / 255f, 10 / 255f);
        superCol = new Color(250 / 255f, 216 / 255f, 86 / 255f, 50 / 255f);
    }
    private void Update() {
        if(Candy.super){
            gameObject.GetComponent<SpriteRenderer>().color = superCol;
        }else{
            gameObject.GetComponent<SpriteRenderer>().color = normalCol;
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tooth") && Candy.super)
        {
            collider.gameObject.GetComponent<Rot>().RotTooth();
        }
    }
}

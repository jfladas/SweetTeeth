using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRot : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tooth") && Candy.super)
        {
            collider.gameObject.GetComponent<Rot>().RotTooth();
        }
    }
}

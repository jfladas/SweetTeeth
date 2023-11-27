using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector2 portVector, mousePos, playerPos, deltaPos;
    private Vector3 worldPos;
    public float moveSpeed, portDelay, portFactor;
    private Quaternion rotPlayer;

    void Start()
    {
        moveSpeed = 6f;

        //seconds between teleport
        portDelay = 1.5f;

        //radius
        portFactor = 8f;
        GameObject.Find("radius").transform.localScale = new Vector2(1,1) * portFactor * 2 / 3;

        rotPlayer.Set(0, 0, 0, 0);

        InvokeRepeating("Teleport", portDelay, portDelay);

        //SuperRot();

    }

    void Update()
    {
        //basic movement
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        transform.rotation = rotPlayer;

        calcVectors();
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

    void Teleport()
    {
        transform.Translate(portVector);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }
/*
    void SuperRot(){
        // Specify the collider you want to check for overlaps
        Collider2D myCollider = GameObject.Find("radius").GetComponent<Collider2D>();

        // Check if the collider is not null
        if (myCollider != null)
        {
            // Create an array to store overlapping colliders
            Collider2D[] colliders = new Collider2D[20]; // You can adjust the size as needed

            // Set up a contact filter to control which layers should be considered
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Default")); // Set your desired layer(s)

            // Check for overlaps and store the results in the colliders array
            int colliderCount = myCollider.OverlapCollider(contactFilter, colliders);

            // Process the overlapping colliders
            for (int i = 0; i < colliderCount; i++)
            {
                // Access each overlapping collider
                Collider2D overlappingCollider = colliders[i];

                // Access the GameObject associated with the collider
                GameObject overlappingObject = overlappingCollider.gameObject;

                if(overlappingObject.tag == "Tooth"){
                    // Do something with the overlapping object
                    overlappingObject.GetComponent<Rot>().Rot();
                }
            }
        }
    }
*/
    
}

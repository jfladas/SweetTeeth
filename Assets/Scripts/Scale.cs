using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //convertDistanceToScale(circle, PlayerMovement.calcPortVector().magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void convertDistanceToScale(GameObject go, float distance)
    {
        Vector2 size = go.transform.lossyScale;
        size.x = distance;
        size.x = (size.x * go.transform.localScale.x) / go.transform.lossyScale.x;
        size.y = go.transform.localScale.y;
        go.transform.localScale = size;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public float deathY = -10f;
    public Vector3 startPosPlayer, startPosCam;
    // Start is called before the first frame update
    void Start()
    {
        startPosPlayer.Set(0, 0, 0);
        startPosCam.Set(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < deathY){
            transform.position = startPosPlayer;
            GameObject.Find("Main Camera").transform.position = startPosCam;
        }
    }
}

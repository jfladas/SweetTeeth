using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyCount : MonoBehaviour
{
    public Sprite count0, count1, count2, count3, count4, countSuper5, countSuper4, countSuper3, countSuper2, countSuper1;
    public Image i;
    void Start()
    {
        i.sprite = count0;
    }
    void Update()
    {
        switch(Candy.candyCount){
            case 0:
                i.sprite = count0;
                break;
            case 1:
                if(Candy.super){
                    i.sprite = countSuper1;
                }else{
                    i.sprite = count1;
                }
                break;
            case 2:
                if (Candy.super)
                {
                    i.sprite = countSuper2;
                }
                else
                {
                    i.sprite = count2;
                }
                break;
            case 3:
                if (Candy.super)
                {
                    i.sprite = countSuper3;
                }
                else
                {
                    i.sprite = count3;
                }
                break;
            case 4:
                if (Candy.super)
                {
                    i.sprite = countSuper4;
                }
                else
                {
                    i.sprite = count4;
                }
                break;
            case 5:
                i.sprite = countSuper5;
                break;
            default:
                Debug.Log("Error!!!! " + Candy.candyCount);
                Candy.candyCount = 0;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickACard : MonoBehaviour
{
    public float RadNum = 0f;


    public void ranNum()
    {
        RadNum = Random.Range(1, 10);
        Debug.Log(RadNum);
    }
}

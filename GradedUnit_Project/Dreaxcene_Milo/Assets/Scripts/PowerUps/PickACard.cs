using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickACard : MonoBehaviour
{
    public int RadNum;

    public int [] AlreadyGot;

    public int counter = 0;


    private void Start()
    {
        AlreadyGot[counter] = 0;  
    }

    public void ranNum()
    {

        RadNum = Random.Range(1, 5);
        Debug.Log(RadNum);

        if (AlreadyGot[counter] == RadNum)
        {
            ranNum();
        }

        else 
        {
            AlreadyGot[counter] = RadNum;
            counter++;
            PickPowerup();
        }       
    }

    public void PickPowerup()
    {
        switch (RadNum) 
        { 
            case 1:
                Debug.Log("HealthPickup");
                break;

            case 2:
                Debug.Log("SpeedPickup");
                break;

            case 3:
                Debug.Log("FasterFireRate");
                break;

            case 4:
                Debug.Log("Bouncing Bullet");
                break;

            case 5:
                Debug.Log("Explosive Bullet");
                break;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickACard : MonoBehaviour
{
    public int RadNum;

    public int [] AlreadyGot; 

    public int counter = 0;

    private bool CopyNumber;


    private void Start()
    {
        AlreadyGot[counter] = 0;

        CopyNumber = false;
    }

    public void ranNum()
    {
        RadNum = Random.Range(1, 6);
        Debug.Log(RadNum);
        
        CheckforDouble();
    }


    public void CheckforDouble() //NS
    {
        int i = 0;

        while(i < AlreadyGot.Length)
        {
            if(AlreadyGot[i] == RadNum)
            {
                CopyNumber = true; //Copy Number equals true
                i++; //Continue loop
            }
            else
            {
                i++;
            }
        }

        
        if(CopyNumber == true)
        {
            CopyNumber=false;
            RadNum = Random.Range(1, 6);
            Debug.Log("New Random Number " + RadNum);
            CheckforDouble();
        }


        else
        {
             AlreadyGot[counter] = RadNum;
             counter++;
             PickPowerup();
        }

        
    }


    public void PickPowerup() //NS
    {
        switch (AlreadyGot[counter]) 
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

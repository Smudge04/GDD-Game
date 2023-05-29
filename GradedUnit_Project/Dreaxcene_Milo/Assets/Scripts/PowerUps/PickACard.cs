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

    public void ranNum() //NS
    {
        if(counter < 5)
        {
            RadNum = Random.Range(1, 6); //JM
            Debug.Log(RadNum); // End of JM

            CheckforDouble();
        }
        else
        {
            Debug.Log("No more Upgrades");
        }
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
            Debug.Log("Choosing Upgrade");
            AlreadyGot[counter] = RadNum;            
            PickPowerup();
        }

        
    }


    public void PickPowerup() //NS
    {
        Debug.Log("Entering Switch Case");

        switch (AlreadyGot[counter]) 
        { 
            case 1:
                Debug.Log("HealthPickup");
                counter++;
                
                break;

            case 2:
                Debug.Log("SpeedPickup");
                counter++;
                break;

            case 3:
                Debug.Log("FasterFireRate");
                counter++;
                break;

            case 4:
                Debug.Log("Bouncing Bullet");
                counter++;
                break;

            case 5:
                Debug.Log("Explosive Bullet");
                counter++;
                break;
        }

    }
} //END OF NS

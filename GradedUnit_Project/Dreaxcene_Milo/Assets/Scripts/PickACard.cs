using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickACard : MonoBehaviour //NS ALL BAR LINES 32-34
{
    public static PickACard Instance;

    public int RadNum;

    public int counter;

    private bool CopyNumber;

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        counter = VariableStatManager.instance.Counter;
        VariableStatManager.instance.AlreadyGot[counter] = 0;

        CopyNumber = false;
    }


    public void ranNum() //NS
    {
        if (counter < 5)
        {
            RadNum = Random.Range(1, 6); //JM
            Debug.Log(RadNum); // End of JM
            VariableStatManager.instance.Counter ++;

            CheckforDouble();
        }
        else
        {
            Debug.Log("No more Upgrades");
            VariableStatManager.instance.Counter = counter;
        }
    }


    public void CheckforDouble() //NS
    {
        int i = 0;

        while (i < VariableStatManager.instance.AlreadyGot.Length)
        {
            if (VariableStatManager.instance.AlreadyGot[i] == RadNum)
            {
                CopyNumber = true; //Copy Number equals true
                i++; //Continue loop
            }
            else
            {
                i++;
            }
        }


        if (CopyNumber == true)
        {
            CopyNumber = false;
            RadNum = Random.Range(1, 6);
            Debug.Log("New Random Number " + RadNum);
            CheckforDouble();
        }


        else
        {
            Debug.Log("Choosing Upgrade");
            VariableStatManager.instance.AlreadyGot[counter] = RadNum;
            PickPowerup();
        }


    }


    public void PickPowerup() //NS
    {
        Debug.Log("Entering Switch Case");

        switch (VariableStatManager.instance.AlreadyGot[counter])
        {
            case 1:
                Debug.Log("HealthPickup");
                VariableStatManager.instance.AddHealth();
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


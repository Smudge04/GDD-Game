using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickACard : MonoBehaviour //NS ALL BAR LINES 32-34
{
    public static PickACard Instance;

    public int RadNum;

    public int counter;

    private bool CopyNumber;

    public GameObject LeftButton, RightButton;

    public GameObject[] UpgradeImages;

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
        LeftButton.GetComponent<Button>().enabled = false;
        RightButton.GetComponent<Button>().enabled = false;

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
                UpgradeImages[0].SetActive(true); 
                UpgradeDisplay.instance.ShowCard(counter);
                counter++;
                break;

            case 2:
                Debug.Log("SpeedPickup");
                VariableStatManager.instance.FasterMovement();
                UpgradeImages[1].SetActive(true);
                UpgradeDisplay.instance.ShowCard(counter);
                counter++;
                break;

            case 3:
                Debug.Log("FasterFireRate");
                VariableStatManager.instance.FireRateUp();
                UpgradeImages[2].SetActive(true);
                UpgradeDisplay.instance.ShowCard(counter);
                counter++;
                break;

            case 4:
                Debug.Log("Shotgun Upgrade");
                VariableStatManager.instance.Shotgun();
                UpgradeImages[3].SetActive(true);
                UpgradeDisplay.instance.ShowCard(counter);
                counter++;
                break;

            case 5:
                Debug.Log("Explosive Bullet");
                UpgradeImages[4].SetActive(true);
                UpgradeDisplay.instance.ShowCard(counter);
                counter++;
                break;
        }

        StartCoroutine(CloseScene());
    }


    IEnumerator CloseScene()
    {
        //Display Text and or card
        yield return new WaitForSeconds(4);
        SceneChange.instance.BackToMerchant(); //Change this line to change back to previous scene
    }
} //END OF NS


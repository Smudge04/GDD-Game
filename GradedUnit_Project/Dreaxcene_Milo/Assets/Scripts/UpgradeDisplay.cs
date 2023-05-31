using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDisplay : MonoBehaviour //NS
{
    public static UpgradeDisplay instance;

    private void Start()
    {
        instance = this;
    }


    public void ShowCard(int counter)
    {
        switch (counter) 
        {
            case 0:
                Debug.Log("Display Pos " + counter);
                break;

            case 1:
                Debug.Log("Display Pos " + counter);
                break;

            case 2:
                Debug.Log("Display Pos " + counter);
                break;

            case 3:
                Debug.Log("Display Pos " + counter);
                break;

            case 4:
                Debug.Log("Display Pos " + counter);
                break;
        }

    }
}

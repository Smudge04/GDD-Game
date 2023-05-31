using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour //NS
{
    public static DisplayLevel Instance;

    public int WorldCounter = 1;
    public int LevelCounter = 1;
    public Text LevelText;


    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        LevelText.text = ("Level: " + WorldCounter.ToString() + " - " + LevelCounter.ToString());

        if(LevelCounter > 7)
        {
            WorldCounter += 1;
            LevelCounter = 1;
        }
    }
}

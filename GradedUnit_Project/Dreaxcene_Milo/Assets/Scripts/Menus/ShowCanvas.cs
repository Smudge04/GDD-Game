using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour //NS
{
    public static ShowCanvas instance;

    public bool CanShow = false;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanShow)
        {
            GetComponent<Canvas>().enabled = true;
        }

        else
        {
            GetComponent<Canvas>().enabled = false;
        }
    }
}

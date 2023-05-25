using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjects : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)//if in range to interact
        {
            if (Input.GetKeyDown(interactKey))//and player presses key
            {
                interactAction.Invoke();//fire event
            }
        }
    }
}

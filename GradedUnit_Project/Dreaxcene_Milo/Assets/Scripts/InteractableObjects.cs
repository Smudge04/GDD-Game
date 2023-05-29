using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractableObjects : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject dialog1;
    public GameObject dialog2;

    // Update is called once per frame
    void Update()
    {
        if (isInRange)//if in range to interact
        {
            if (Input.GetKeyDown(interactKey))//and player presses key
            {
                interactAction.Invoke();//fire event
                Debug.Log("interacted");
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player Now In Range");
            dialog1.SetActive(true);
            dialog2.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player Now Not In Range");
            dialog1.SetActive(false);
            dialog2.SetActive(true);
        }
    }
}

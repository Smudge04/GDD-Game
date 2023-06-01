using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour //NS
{
    public static DestroyEnemies instance;

    public GameObject RoomEnemyGameObject;

    private void Start()
    {
        instance = this;
    }
 
    public void FixedUpdate()
    {
        RoomEnemyGameObject = GameObject.FindGameObjectWithTag("RoomEnemies");
    }

    public void Destroy()
    {
        RoomEnemyGameObject.SetActive(false);
        GetComponent<DestroyEnemies>().enabled = false;
    }
}

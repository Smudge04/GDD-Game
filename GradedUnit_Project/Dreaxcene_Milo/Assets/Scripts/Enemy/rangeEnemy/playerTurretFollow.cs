using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTurretFollow : MonoBehaviour
{

    private Transform playerPos;
    Vector2 playerDir;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Vector2 targetPos = playerPos.transform.position;
        playerDir = targetPos -(Vector2)transform.position;
        transform.up = playerDir;
    }
}

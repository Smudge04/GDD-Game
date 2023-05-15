using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTurretFollow : MonoBehaviour
{

    private Transform playerPos;//varible to store the player position - JM
    Vector2 playerDir;//varible to store the players direction - JM

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;//find the game object with the Player tag - JM
    }
    void Update()
    {
        Vector2 targetPos = playerPos.transform.position;
        playerDir = targetPos -(Vector2)transform.position;
        transform.up = playerDir;
    }
}

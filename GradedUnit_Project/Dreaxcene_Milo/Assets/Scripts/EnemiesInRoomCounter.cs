using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesInRoomCounter : MonoBehaviour //NS
{
    public static EnemiesInRoomCounter instance;

    [SerializeField] public int EnemyCount;


    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if(EnemyCount <= 0)
        {
            GetComponent<SpriteRenderer>().enabled = true; //Sprite renderer on
            GetComponent<BoxCollider2D>().enabled = true; //Collider on
        }
    }
}

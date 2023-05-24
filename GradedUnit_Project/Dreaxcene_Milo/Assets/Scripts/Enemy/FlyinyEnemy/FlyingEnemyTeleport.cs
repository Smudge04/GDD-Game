using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyTeleport : MonoBehaviour
{
    
    public float teleportTime = 5;

    void Start()
    {
        

        /*transform.position.y = 3;
         transform.rotation.x = 0;*/

        InvokeRepeating("Teleport", teleportTime, teleportTime);
    }

    
    void Teleport()
    {
        transform.position += Random.insideUnitSphere * 10;
    }


}

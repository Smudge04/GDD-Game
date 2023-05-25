using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/AddHeart")]

public class healthBuff : PowerUpEffect
{
    
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().numOfHearts += 3;
        target.GetComponent<Health>().health += 3;
    }
}

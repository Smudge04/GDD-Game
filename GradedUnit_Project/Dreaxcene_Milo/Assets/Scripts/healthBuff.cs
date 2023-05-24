using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().health.value += amount;
    }

}

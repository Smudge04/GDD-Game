using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallerDashCoolDown : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().TimeBtwDash /= 2;
    }
}

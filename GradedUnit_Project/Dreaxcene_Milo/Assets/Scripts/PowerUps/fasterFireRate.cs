using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/fasterFireRate")]
public class fasterFireRate : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<Gun>().FireRate *= 2;
    }
}

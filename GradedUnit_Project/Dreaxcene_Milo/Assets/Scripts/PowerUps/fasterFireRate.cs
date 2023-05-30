using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/fasterFireRate")]
public class fasterFireRate : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        Debug.Log("does this shi work");
        target.GetComponent<Gun>().FireRate += 2;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Upgrades/SpeedBoost")]
public class speedBoost : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().SavedSpeed *= 2;
        target.GetComponent<PlayerMovement>().dashSpeed *= 2;
    }
}
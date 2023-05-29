using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/SniperShot")]
public class sniperShot : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        Debug.Log("does this shi work");
        target.GetComponent<Gun>().BulletSpeed += 2;
        Debug.Log(target.GetComponent<Gun>().BulletSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnim : MonoBehaviour
{
    public Animator animator;

    public void BulletShake() //Sets trigger to shake camera each time the gun is used NS
    {
        animator.SetTrigger("BulletShake");
    }
}

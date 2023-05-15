using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnim : MonoBehaviour
{
    public Animator animator;

    public void BulletShake()
    {
        animator.SetTrigger("BulletShake");
    }
}

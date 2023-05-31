//CB
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemyKnockback: MonoBehaviour 
{
    public float stunDuration;//how long the stun will last(seconds)
    public float force;//how much force the stun will have

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))//find objects with the "Enemy" tag
        {
            Rigidbody2D Enemy = other.GetComponent<Rigidbody2D>(); //gets the rigidbody for objects with the "Enemy" tag
            if(Enemy != null)
            {
                Enemy.isKinematic = false; //disabled the kinematic rigidbody
                Vector2 difference = Enemy.transform.position - transform.position;
                difference = difference.normalized * force;
                Enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackDistance(Enemy));//beigns the knockback distance coroutine
            }
        }
    }

    private IEnumerator KnockbackDistance(Rigidbody2D Enemy)
    {
        if(Enemy != null)
        {
            yield return new WaitForSeconds(stunDuration);//checks how long the stun duration will last for
            Enemy.velocity = Vector2.zero;
            Enemy.isKinematic = true;//re-enables the kinematic rigidbody after stunDuration is finished
        }

    }
}
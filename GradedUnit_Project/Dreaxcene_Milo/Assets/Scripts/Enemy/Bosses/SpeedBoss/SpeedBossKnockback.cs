//CB
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBossKnockback: MonoBehaviour 
{
    public float stunDuration;//how long the stun will last(seconds)
    public float force;//how much force the stun will have

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Boss"))//find objects with the "Boss" tag
        {
            Rigidbody2D Boss = other.GetComponent<Rigidbody2D>(); //gets the rigidbody for objects with the "Boss" tag
            if(Boss != null)
            {
                Boss.isKinematic = false; //disabled the kinematic rigidbody
                Vector2 difference = Boss.transform.position - transform.position;
                difference = difference.normalized * force;
                Boss.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(BKnockbackDistance(Boss));//beigns the knockback distance coroutine
            }
        }
    }

    private IEnumerator BKnockbackDistance(Rigidbody2D Boss)
    {
        if(Boss != null)
        {
            yield return new WaitForSeconds(stunDuration);//checks how long the stun duration will last for
            Boss.velocity = Vector2.zero;
            Boss.isKinematic = true;//re-enables the kinematic rigidbody after stunDuration is finished
        }

    }
}
//CB
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemyKnockback: MonoBehaviour 
{
    public float stunDuration;
    public float force; 

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D Enemy = other.GetComponent<Rigidbody2D>();
            if(Enemy != null)
            {
                Enemy.isKinematic = false;
                Vector2 difference = Enemy.transform.position - transform.position;
                difference = difference.normalized * force;
                Enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockbackDistance(Enemy));
            }
        }
    }

    private IEnumerator KnockbackDistance(Rigidbody2D Enemy)
    {
        if(Enemy != null)
        {
            yield return new WaitForSeconds(stunDuration);
            Enemy.velocity = Vector2.zero;
            Enemy.isKinematic = true;
        }

    }
}
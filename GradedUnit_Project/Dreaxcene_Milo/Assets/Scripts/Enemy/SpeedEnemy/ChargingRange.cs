using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingRange : MonoBehaviour
{
    [SerializeField] float ChargeSpeed;
    private bool CanCharge = true;
    public GameObject ChargeRange;
    public GameObject ToCloseToCharge;

    [SerializeField] ParticleSystem EnemyParticle;

    private void Awake()
    {
        ChargeRange.GetComponent<CircleCollider2D>().enabled = true;    //gets collider range to allow enemy to charge at a set distance
        ToCloseToCharge.GetComponent<CircleCollider2D>().enabled = false; //gets collider range for charging restrictions so it wont charge too close to the player
    }

    private void OnTriggerEnter2D(Collider2D other) //Checks for Speed Enemy
    {
        if (other.gameObject.tag == "Player")   //looks for objects with the "Player" tag
        {
            StartCoroutine(EnemyCharge());     //begins the charge routine if the "Player" tag is found
        }
    }

    public IEnumerator EnemyCharge() //routine that will be called by GroundEnemyDistance script to cause the enemy to move faster and go invisible
    {
        ToCloseToCharge.GetComponent<CircleCollider2D>().enabled = true;

        if (CanCharge == true)
        {
            CanCharge = false;
            ChargeRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<EnemyMovement>().speed = 0; //sets speed to 0 
            Instantiate(EnemyParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect           
            
            yield return new WaitForSeconds(1.5f);

            EnemyParticle.Stop();     //disables the charging particles
            GetComponent<EnemyMovement>().speed = ChargeSpeed; //speed up
            GetComponent<ParticleSystem>().enableEmission = true;

        }

        else
        {
            GetComponent<EnemyMovement>().speed = 0;
            GetComponent<ParticleSystem>().enableEmission = false; //stop particle Effect
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            GetComponent<EnemyMovement>().speed = 1;

            yield return new WaitForSeconds(2);

            ToCloseToCharge.GetComponent<CircleCollider2D>().enabled = false;
            ChargeRange.GetComponent<CircleCollider2D>().enabled = true;
            CanCharge = true;       //allows the enemy to charge again
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingRange : MonoBehaviour
{
    [SerializeField] float DigSpeed;
    private bool CanDig = true;
    public GameObject DigRange;
    public GameObject ToCloseToDig;

    [SerializeField] ParticleSystem EnemyParticle;

    private void Awake()
    {
        DigRange.GetComponent<CircleCollider2D>().enabled = true;
        ToCloseToDig.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //Checks for Ground Enemy NS
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(EnemyDig());
        }
    }

    public IEnumerator EnemyDig() //routine that will be called by GroundEnemyDistance script to cause the enemy to move faster and go invisible
    {
        ToCloseToDig.GetComponent<CircleCollider2D>().enabled = true;

        if (CanDig == true)
        {
            CanDig = false;
            DigRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<EnemyMovement>().speed = 0; //speed = 0
            GetComponent<SpriteRenderer>().enabled = false; //Turn off sprite renderer
            GetComponent<BoxCollider2D>().enabled = false; //Turn off collider
            GetComponentInChildren<Canvas>().enabled = false; //turn off healthbar
            Instantiate(EnemyParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect           
            
            yield return new WaitForSeconds(1.5f);

            EnemyParticle.Stop();
            GetComponent<EnemyMovement>().speed = DigSpeed; //Speed up
            GetComponent<ParticleSystem>().enableEmission = true;

        }

        else
        {
            GetComponent<EnemyMovement>().speed = 0;
            GetComponent<ParticleSystem>().enableEmission = false; //Stop Particle Effect
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(0.2f);
            GetComponent<EnemyMovement>().speed = 1;

            yield return new WaitForSeconds(2);

            ToCloseToDig.GetComponent<CircleCollider2D>().enabled = false;
            DigRange.GetComponent<CircleCollider2D>().enabled = true;
            CanDig = true;
        }
    }
}

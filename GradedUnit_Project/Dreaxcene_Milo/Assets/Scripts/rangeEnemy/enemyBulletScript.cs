using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class enemyBulletScript : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;//this will create a direction towards the player
        rb.velocity = new Vector2(direction.x,direction.y).normalized * force;//shot will travel towards the player

        float rot = Mathf.Atan2(-direction.y,-direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 5)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            VariableStatManager.instance.health --;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall")) //NS
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(waiter()); //When bullet prefab is spawned, begins Timer
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3); //Waits for 3 seconds before deleting the game object
        Destroy(this.gameObject);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); //If the bullet collides with anything before the 3 seconds it destroys the game object
    }
}

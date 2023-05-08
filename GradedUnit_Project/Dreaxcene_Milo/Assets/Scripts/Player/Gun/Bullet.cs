using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int GunDamage;

    private void Start() //NS
    {
        GunDamage = 1; //Sets gundamage at the start of the game
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag) //Checks for objects tags
        {
            case "Wall":
                Destroy(this.gameObject); //if it is the border, destroy bullet
                break;
            case "Enemy": //If it is an enemy
                Destroy(this.gameObject); //Destroy bullet
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(GunDamage); //begin take damage function, passing damage int 
                break;
        }
    }
}

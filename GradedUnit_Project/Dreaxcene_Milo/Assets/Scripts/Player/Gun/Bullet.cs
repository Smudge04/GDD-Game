using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float GunDamage; //NS

    private void Awake()
    {
        GunDamage = VariableStatManager.instance.GunDamage; //stores the current damage the gun can do
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
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(GunDamage); //begin take damage function, passing damage float 
                break;
            case "Boss": //if it collides with boss
                Destroy(this.gameObject);
                other.gameObject.GetComponent<BossHealth>().TakeDamage(GunDamage); //begin take damage to boss passing damage float
                break;
        }
    }
}

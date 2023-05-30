// using UnityEngine;

// public class ExplosiveBullet : MonoBehaviour
// {

//     public int GunDamage;
//     public float ExplosionSplashRange = 1;
//     public GameObject BulletExplode;

//  private void Start()
//     {
//         GunDamage = 1; //sets damage when game starts
//     }

// //CB
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (ExplosionSplashRange > 0)
//         {
//            var hitColliders = Physics2D.OverlapCircleAll(transform.position,ExplosionSplashRange);
//            foreach (var hitCollider in hitColliders)
//            {
//                 var enemy  = hitCollider.GetComponent<EnemyHealth>();
//                 if (enemy)
//                 {
//                     var closestPoint = hitCollider.ClosestPoint(transform.position);
//                     var distance = Vector3.Distance(closestPoint, transform.position);

//                     var damagePercent = Mathf.InverseLerp(ExplosionSplashRange, 0, distance);
//                     enemy.TakeDamage(damagePercent * GunDamage); //cannot convert float to int if removing "(int)", doesnt work as is
//                 }
//            }
//         }
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         switch (other.gameObject.tag) //Checks for objects tags
//         {
//             case "Wall":
//                 Destroy(this.gameObject); 
//                 Instantiate(BulletExplode, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect
//                 break;
//             case "Enemy":
//                 Destroy(this.gameObject); //destroys bullet
//                 Instantiate(BulletExplode, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect
//                 other.gameObject.GetComponent<EnemyHealth>().TakeDamage(GunDamage); //begin take damage function, passing damage int 
//                 break;
//             case "Boss":
//                 Destroy(this.gameObject);
//                 Instantiate(BulletExplode, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect
//                 other.gameObject.GetComponent<BossHealth>().TakeDamage(GunDamage);
//                 break;
//         }
//     }

// }

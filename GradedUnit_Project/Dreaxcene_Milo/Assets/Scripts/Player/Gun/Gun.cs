using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float OffSet;
    public Transform ShotPos;
    public GameObject Bullet;
    public int BulletAmount;
    public float Spread, BulletSpeed;

    public float FireRate; //variable for fire rate
    public float FiringInterval; //Variable for interval between shots

    void Update() //JM - created basic gun script
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + OffSet, Vector3.forward);
        if (Input.GetButton("Fire1") && (Time.time > FiringInterval)) //If player presses fire and time is greater than the firing interval
        {
            Shoot(); //Begin shoot function
            FiringInterval = Time.time + FireRate; //Firing interval is equal to time plus fire rate
        }
    }

    void Shoot()
    {
        for (int i = 0; i < BulletAmount; i++) 
        {
            GameObject b = Instantiate(Bullet, ShotPos.position,ShotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation*Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(- Spread, Spread);
            brb.velocity = (dir + pdir) * BulletSpeed;
        }
    }
}

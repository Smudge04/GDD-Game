using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float OffSet;
    public Transform ShotPos;
    public GameObject Bullet;
    private int BulletAmount;
    private float Spread, BulletSpeed;

    private float FireRate; //variable for fire rate
    private float FiringInterval; //Variable for interval between shots

    private CamAnim CamAnim;

    private void Awake()
    {
        BulletAmount = VariableStatManager.instance.BulletAmount;
        Spread = VariableStatManager.instance.Spread;
        BulletSpeed = VariableStatManager.instance.BulletSpeed;
        FireRate = VariableStatManager.instance.FireRate;
        FiringInterval = VariableStatManager.instance.FiringInterval;
    }

    private void Start()
    {
        CamAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamAnim>(); //Stores animation screenshake into variable shake    
    }

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
            CamAnim.BulletShake();
            GameObject b = Instantiate(Bullet, ShotPos.position,ShotPos.rotation);
            Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation*Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(- Spread, Spread);
            brb.velocity = (dir + pdir) * BulletSpeed;
        }

    }
}

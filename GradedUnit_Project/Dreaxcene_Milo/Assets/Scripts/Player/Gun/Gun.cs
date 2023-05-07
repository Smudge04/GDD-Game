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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + OffSet, Vector3.forward);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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

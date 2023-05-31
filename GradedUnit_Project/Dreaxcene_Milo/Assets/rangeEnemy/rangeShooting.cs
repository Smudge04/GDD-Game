using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeShooting : MonoBehaviour

{
    public GameObject bullet;//variable to store the Bullet - JM
    public GameObject bulletPos;//varible to store the position of bullet - JM

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)// if timer is greater than 2 - JM
        {
            timer = 0;//set timer back to 0 - JM
            shoot();//run the shoot function - JM
        }
    }

    void shoot()//shoot function
    {
        Instantiate(bullet, bulletPos.transform.position, Quaternion.identity);
    }
}

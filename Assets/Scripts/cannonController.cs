using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{

    public bool isFiring;

    public bulletControler bullet;
    public float bulletSpeed;
    public float cooldown;
    public float shotCounter;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string playerIndex = gameObject.GetComponentInParent<TankMovement>().playerIndex;
        isFiring = Input.GetButtonDown("P" + playerIndex + " R1");

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = cooldown;
                bulletControler newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletControler;
                newBullet.speed = bulletSpeed;
            }
            else
            {
                shotCounter = 0;
            }

        }
    }
}

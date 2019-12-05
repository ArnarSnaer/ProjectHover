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
    public AudioSource shoot;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCounter > 0)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter < 0)
            {
                shotCounter = 0;
            }
            
        }
        
    }

    void FixedUpdate()
    {
        string playerIndex = gameObject.GetComponentInParent<TankMovement>().playerIndex;
        isFiring = Input.GetButton("P" + playerIndex + " R1");

        if (isFiring && shotCounter == 0.0f)
        {
            shotCounter = cooldown;
            bulletControler newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletControler;
            shoot.Play();
            newBullet.speed = bulletSpeed;
        }
    }
}

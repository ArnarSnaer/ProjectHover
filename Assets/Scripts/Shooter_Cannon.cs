using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Cannon : MonoBehaviour
{

    public bool isFiring;

    public bulletControler bullet;
    public float bulletSpeed;
    public float cooldown;
    public float shotCounter;
    public Transform firePoint;
    public AudioSource shoot;
    public GameObject impactParticle;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target);
        if (shotCounter > 0)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter < 0)
            {
                shotCounter = 0;
            }
            
        }
        if (shotCounter == 0.0f){
            shotCounter = cooldown;
            bulletControler newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as bulletControler;
            Instantiate(impactParticle, firePoint.position, firePoint.rotation);
            shoot.Play();
            newBullet.speed = bulletSpeed;
        }
        
    }

    void FixedUpdate()
    {

    }
    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.5f);
        shotCounter = 0.0f;
        Pathfinding.AIDestinationSetter ai_destination = this.GetComponent<Pathfinding.AIDestinationSetter>();
        target = ai_destination.target;
    }
}

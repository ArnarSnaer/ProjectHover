﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbilities : MonoBehaviour
{
    private string playerIndex;
    public float pushCooldown;
    public float wallCooldown;
    public float domeCooldown;
    public float shieldTime;

    public bulletControler bullet;
    public GameObject guardianShield;
    public GameObject pushWall;
    public AudioSource pushClip;
    public AudioSource wallClip;
    private Transform point;
    private Animation anim;

    [HideInInspector]
    public float pushCountdown;
    
    [HideInInspector]
    public float wallCountdown;
    
    [HideInInspector]
    public float domeCountdown;

    // Start is called before the first frame update
    void Start()
    {
        playerIndex = gameObject.GetComponentInParent<TankMovement>().playerIndex;
        anim = gameObject.GetComponent<Animation>();
        pushCountdown = 0.0f;
        wallCountdown = 0.0f;
        domeCountdown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushCountdown > 0)
        {
            pushCountdown -= Time.deltaTime;
            if (pushCountdown < 0) pushCountdown = 0;
        } 
        if (wallCountdown > 0)
        {
            wallCountdown -= Time.deltaTime;
            if (wallCountdown < 0) wallCountdown = 0;
        } 
        if (domeCountdown > 0)
        {
            domeCountdown -= Time.deltaTime;
            if (domeCountdown < 0) domeCountdown = 0;
        } 
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("P" + playerIndex + " L1") && pushCountdown == 0.0f)
        {
            Shotgun();
            //Push();
            pushCountdown = pushCooldown;
        }

        if (Input.GetButtonDown("P" + playerIndex + " L2") && wallCountdown == 0.0f)
        {
            PlaceWall();
            wallCountdown = wallCooldown;
        }

        if (Input.GetButtonDown("P" + playerIndex + " PS4 Circle") && domeCountdown == 0.0f)
        {
            // Not implimented
            Dome();
            domeCountdown = domeCooldown;
        }

    }

    void Push()
    {
        point = this.transform.Find("BulletSpawn");
        GameObject push = Instantiate(pushWall, point.position, point.rotation) as GameObject;
        pushClip.Play();
        Destroy(push, 0.35f);
    }

    void PlaceWall()
    {
        point = this.transform.Find("WallSpawn");
        GameObject shield = Instantiate(guardianShield, point.position, point.rotation) as GameObject;
        wallClip.Play();
        Destroy(shield, shieldTime);
    }

    void Dome()
    {
        // Spawns a dome around the player which will block enemies
    }

    void Shotgun()
    {
        point = this.transform.Find("BulletSpawn");
        float bulletSpeed = 10f;
        //shoot.Play();
        Debug.Log(point);

        Quaternion point1 = new Quaternion(point.rotation.x, point.rotation.y, point.rotation.z - 40, 1); 
        Quaternion point2 = new Quaternion(point.rotation.x, point.rotation.y, point.rotation.z - 20, 1);
        Quaternion point4 = new Quaternion(point.rotation.x, point.rotation.y, point.rotation.z + 20, 1);
        Quaternion point5 = new Quaternion(point.rotation.x, point.rotation.y, point.rotation.z + 40, 1);

        bulletControler newBullet1 = Instantiate(bullet, point.position, point1)            as bulletControler;
        bulletControler newBullet2 = Instantiate(bullet, point.position, point2)            as bulletControler;
        bulletControler newBullet3 = Instantiate(bullet, point.position, point.rotation)    as bulletControler;
        bulletControler newBullet4 = Instantiate(bullet, point.position, point4)            as bulletControler;
        bulletControler newBullet5 = Instantiate(bullet, point.position, point5)            as bulletControler;

        newBullet1.speed = bulletSpeed;
        newBullet2.speed = bulletSpeed;
        newBullet3.speed = bulletSpeed;
        newBullet4.speed = bulletSpeed;
        newBullet5.speed = bulletSpeed;
    }
}

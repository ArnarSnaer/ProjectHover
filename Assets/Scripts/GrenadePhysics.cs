using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePhysics : MonoBehaviour
{
    Transform point;
    public bulletControler bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D enemy){
        if(enemy != null){
            point = this.transform;
            float bulletSpeed = 10f;
            //shoot.Play();
            bulletControler newBullet1 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z - 150)) as bulletControler;
            bulletControler newBullet2 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z - 120)) as bulletControler;
            bulletControler newBullet3 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z - 90)) as bulletControler;
            bulletControler newBullet4 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z - 60)) as bulletControler;
            bulletControler newBullet5 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z - 30)) as bulletControler;
            bulletControler newBullet6 = Instantiate(bullet, point.position, point.rotation)    as bulletControler;
            bulletControler newBullet7 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 30)) as bulletControler;
            bulletControler newBullet8 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 60)) as bulletControler;
            bulletControler newBullet9 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 90)) as bulletControler;
            bulletControler newBullet10 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 120)) as bulletControler;
            bulletControler newBullet11 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 150)) as bulletControler;
            bulletControler newBullet12 = Instantiate(bullet, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 180)) as bulletControler;

            newBullet1.speed = bulletSpeed;
            newBullet2.speed = bulletSpeed;
            newBullet3.speed = bulletSpeed;
            newBullet4.speed = bulletSpeed;
            newBullet5.speed = bulletSpeed;
            newBullet6.speed = bulletSpeed;
            newBullet7.speed = bulletSpeed;
            newBullet8.speed = bulletSpeed;
            newBullet9.speed = bulletSpeed;
            newBullet10.speed = bulletSpeed;
            newBullet11.speed = bulletSpeed;
            newBullet12.speed = bulletSpeed;
            Destroy (this.gameObject);
        }
    }
}

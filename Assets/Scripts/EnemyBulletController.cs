using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private int bullet_damage = 10;
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
            if(enemy.gameObject.tag == "Player"){
                Destroy (this.gameObject);
                TankMovement tank = enemy.gameObject.GetComponent<TankMovement>();
                tank.player_flash();
                GameManager.damagePlayers(bullet_damage);
            }
            else if(enemy.gameObject.tag != "EnemyBullet" &&
                enemy.gameObject.tag != "PlayerBullet"){    
                    Destroy(this.gameObject);
            }
        }
    }
}

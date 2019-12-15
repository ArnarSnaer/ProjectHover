using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
{

    private int bullet_damage = 10;
    public GameObject explosionRef;
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
            Instantiate(explosionRef, this.transform.position, Quaternion.identity);
            if(enemy.gameObject.tag == "enemy"){
                Destroy (this.gameObject);
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.flash();
                damage.health.Damage(bullet_damage);
            }
            else if(enemy.gameObject.tag == "Player"){
                Destroy (this.gameObject);
                enemy.gameObject.GetComponent<TankMovement>().moveSpeed = 10f;
            }
            else if(enemy.gameObject.tag != "EnemyBullet" &&
                enemy.gameObject.tag != "PlayerBullet"){    
                    Destroy(this.gameObject);
            }
        }
    }
}

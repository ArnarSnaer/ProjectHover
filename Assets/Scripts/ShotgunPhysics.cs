using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPhysics : MonoBehaviour
{
    // Start is called before the first frame update

    public int bulletDamage;
    public AudioSource ice;


    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            if(enemy.gameObject.tag == "enemy"){
                Destroy (this.gameObject);

                // Play shotgun sound
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.flash();
                damage.slowed();

            }

            else if(enemy.gameObject.name != "Bullet" &&
                enemy.gameObject.name != "Bullet(Clone)"){    
                    Destroy(this.gameObject);
            }
        }
    }

}

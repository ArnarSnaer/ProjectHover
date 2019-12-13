using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPhysics : MonoBehaviour
{
    // Start is called before the first frame update

    public int bulletDamage;
    public float force;
    public AudioSource ice;


    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            if(enemy.gameObject.tag == "enemy"){
                Destroy (this.gameObject);

                // Play shotgun sound
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.flash();
                damage.health.Damage(bulletDamage);

                StartCoroutine(slowed(enemy));
            }

            else if(enemy.gameObject.name != "Bullet" &&
                enemy.gameObject.name != "Bullet(Clone)"){    
                    Destroy(this.gameObject);
            }
        }
    }

    IEnumerator slowed(Collision2D enemy)
    {

        float oldSpeed = enemy.gameObject.GetComponent<Pathfinding.IAstarAI>().maxSpeed;
        enemy.gameObject.GetComponent<Pathfinding.IAstarAI>().maxSpeed = 0.5f;
        // Play Ice Sound

        yield return new WaitForSeconds(2.0f);
        enemy.gameObject.GetComponent<Pathfinding.IAstarAI>().maxSpeed = oldSpeed;

        //enemy.gameObject.GetComponent<Pathfinding.IAstarAI>().maxSpeed = oldSpeed;

    }

}

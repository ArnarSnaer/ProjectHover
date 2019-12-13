using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPhysics : MonoBehaviour
{
    // Start is called before the first frame update

    public int bulletDamage;
    public float force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            if(enemy.gameObject.tag == "enemy"){
                //StartCoroutine(Damaged(enemy.gameObject));
                Destroy (this.gameObject);
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.flash();
                damage.health.Damage(bulletDamage);

                enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.up * force, ForceMode2D.Impulse);
                Debug.Log("Force added!");
            }


            else if(enemy.gameObject.name != "Bullet" &&
                enemy.gameObject.name != "Bullet(Clone)"){    
                    Destroy(this.gameObject);
            }
        }
    }
}

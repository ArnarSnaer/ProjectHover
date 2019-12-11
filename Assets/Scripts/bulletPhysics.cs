using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
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
            if(enemy.gameObject.tag == "enemy"){
                //StartCoroutine(Damaged(enemy.gameObject));
                Destroy (this.gameObject);
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.flash();
                damage.health.Damage(bullet_damage);
            }
            else if(enemy.gameObject.name != "Bullet" &&
                enemy.gameObject.name != "Bullet(Clone)"){    
                    Destroy(this.gameObject);
            }
        }
    }
}

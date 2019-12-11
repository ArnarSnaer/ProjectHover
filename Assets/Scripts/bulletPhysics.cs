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
    IEnumerator Damaged(GameObject enemy) {
        Renderer enemy_color = enemy.GetComponent<Renderer>();
        Debug.Log(enemy_color.material.color);
        Color old_color = enemy_color.material.color;
        enemy_color.material.color = new Color (1,0,0,1);
        yield return null;
        // yield return new WaitForSeconds(0.5f);
        Debug.Log("Made it!");
        enemy_color.material.color = old_color;
    }
}

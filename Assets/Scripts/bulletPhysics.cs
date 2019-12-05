using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
{
    private SpawnManager _spawnManager;
    public AudioSource enemyKill;

    private int bullet_damage = 10;
    // Start is called before the first frame update
    void Start()
    {
      //  _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            if(enemy.gameObject.tag == "enemy"){
                Destroy (this.gameObject);
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.health.Damage(bullet_damage);
                //Death();
            }
            else if(enemy.gameObject.name != "Bullet" &&
                enemy.gameObject.name != "Bullet(Clone)"){    
                    Destroy(this.gameObject);
                }
            }
    }
        }

    private void Death()
    {
        _spawnManager.EnemyDefeated();
    }
}

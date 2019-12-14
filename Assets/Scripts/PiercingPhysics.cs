using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingPhysics : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        pierces = max_pierces;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int max_pierces;
    public int bullet_damage = 10;
    private int pierces; 
    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            pierces -= 1;
            StartCoroutine(Piercing());
            if(enemy.gameObject.tag == "enemy"){
                if(pierces <= 0){
                    Destroy (this.gameObject);
                }
                enemyHealth damage = enemy.gameObject.GetComponent<enemyHealth>();
                damage.flash();
                damage.health.Damage(bullet_damage);
            }
            else if(enemy.gameObject.tag == "Player"){
                if(pierces <= 0){
                    Destroy (this.gameObject);
                }
                enemy.gameObject.GetComponent<TankMovement>().moveSpeed = 10f;
            }
            else if(enemy.gameObject.tag == "OutOfBounds") Destroy (this.gameObject);
            else if(enemy.gameObject.tag != "EnemyBullet" &&
                enemy.gameObject.tag != "PlayerBullet"){    
                if(pierces <= 0){
                    Destroy (this.gameObject);
                }
            }
        }
    }
    IEnumerator Piercing()
    {
        body.isKinematic = true;
        yield return new WaitForSeconds(0.5f);
        body.isKinematic = false;
    }
}

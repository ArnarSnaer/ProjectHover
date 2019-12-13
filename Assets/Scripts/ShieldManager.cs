using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int damage_amount;
    void OnCollisionEnter2D(Collision2D enemy){
        if(enemy != null){
            if(enemy.gameObject.GetComponent<TankMovement>() != null){
                TankMovement tank = enemy.gameObject.GetComponent<TankMovement>();
                tank.player_flash();
                GameManager.damagePlayers(damage_amount);
                enemyHealth damage = this.transform.parent.gameObject.GetComponent<enemyHealth>();
                damage.health.Damage(1000);
            }
        }
    }
}

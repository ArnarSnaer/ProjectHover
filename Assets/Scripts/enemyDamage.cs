using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    private SpawnManager _spawnManager;

    public int damage_amount;
    void OnCollisionEnter2D(Collision2D enemy){
        if(enemy != null){
            if(enemy.gameObject.GetComponent<TankMovement>() != null){
                enemyHealth damage = this.gameObject.GetComponent<enemyHealth>();
                damage.health.Damage(1000);
                TankMovement tank = enemy.gameObject.GetComponent<TankMovement>();
                tank.player_flash();
                GameManager.damagePlayers(damage_amount);
            }
        }
    }
}

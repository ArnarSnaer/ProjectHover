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
                GameManager.damagePlayers(damage_amount);
                Destroy (this.gameObject);
                _spawnManager.EnemyDefeated();
                Debug.Log("Enemy defeated!");
            }
        }
    }
}

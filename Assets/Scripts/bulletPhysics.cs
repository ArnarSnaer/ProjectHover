﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
{
    private SpawnManager _spawnManager;
    public AudioSource enemyKill;

    //Add to this array new names of enemy objects or if names of enemies are altered
    private string[] enemies = {"Base Enemy", "Base Enemy(Clone)"};
    private bool isEnemy(GameObject thing){
        string name = thing.name;
        foreach(string enemy in enemies){
            if(enemy == name) return true;
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null)
    {
        if(isEnemy(enemy.gameObject)){
            Destroy (this.gameObject);
            Destroy (enemy.gameObject);
            enemyKill.Play();
            Death();
        }
        else if(enemy.gameObject.name != "Bullet" ||
            enemy.gameObject.name == "Bullet(Clone)"){    
                Destroy(this.gameObject);
            }
    }
        }

    private void Death()
    {
        _spawnManager.EnemyDefeated();
    }
}

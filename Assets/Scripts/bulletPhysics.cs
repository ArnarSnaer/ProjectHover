﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPhysics : MonoBehaviour
{
    private string[] enemies = {"Base Enemy"};
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            if(isEnemy(enemy.gameObject)){
                Destroy (this.gameObject);
                Destroy (enemy.gameObject);
            }
        }
    }
}

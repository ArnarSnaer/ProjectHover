﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged; 
    private int health;
    private int healthMax;

    public HealthSystem(int health){
        this.health = health;
        this.healthMax = health;
    }

    public int GetHealth(){
        return health;
    }

    public float GetHealthPercent(){
        return (float)health/healthMax;
    }
    public void Damage(int damage_amount){
        health -= damage_amount;
        if(health < 0) health = 0;
        if(OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}

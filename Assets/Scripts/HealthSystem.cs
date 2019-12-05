using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged; 
    public event EventHandler Ded;
    private int health;
    private int healthMax;

    public HealthSystem(int max_health){
        this.health = max_health;
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
        if(health <= 0){
            health = 0;
            Ded(this, EventArgs.Empty);
        }
        if(OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(int heal_amount){
        health += heal_amount;
        if(health > healthMax){
            health = healthMax;
        }
        if(OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}

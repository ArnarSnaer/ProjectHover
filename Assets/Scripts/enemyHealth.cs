using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public static HealthSystem playerHealth;
    // Start is called before the first frame update
    
    void Start()
    {
        playerHealth = new HealthSystem(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void damagePlayers(int damage){
        playerHealth.Damage(damage);
    }

}

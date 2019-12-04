using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public static HealthSystem playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = new HealthSystem(100);
        healthBar.Setup(playerHealth);
        playerHealth.Damage(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void damagePlayers(int damage){
        Debug.Log("Made it");
        playerHealth.Damage(damage);
    }
}

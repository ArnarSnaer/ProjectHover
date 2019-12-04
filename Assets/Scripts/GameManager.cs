using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        HealthSystem playerHealth = new HealthSystem(100);
        healthBar.Setup(playerHealth);
        playerHealth.Damage(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

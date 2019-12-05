using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public static HealthSystem playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = new HealthSystem(100);
        healthBar.Setup(playerHealth);
        playerHealth.Ded += HealthSystem_Ded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void damagePlayers(int damage){
        playerHealth.Damage(damage);
    }

    private void HealthSystem_Ded(object sender, System.EventArgs e){
        Debug.Log("Game over!");
        GameOver();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

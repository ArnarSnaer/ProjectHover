using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;
    public static HealthSystem playerHealth;
    public GameObject explosionRef;
    public AudioSource death;
    public TMPro.TextMeshProUGUI scoreLabel;


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

    public static void healPlayers(int heal_amount){
        playerHealth.Heal(heal_amount);
    }

    private void HealthSystem_Ded(object sender, System.EventArgs e){
        GameOver();
    }

    void GameOver()
    {
        TankMovement[] players = FindObjectsOfType<TankMovement>();
        TankMovement player1 = players[0];
        TankMovement player2 = players[1];
        Destroy(player1.gameObject);
        Instantiate(explosionRef, player1.transform.position, Quaternion.identity);
        Destroy(player2.gameObject);
        Instantiate(explosionRef, player2.transform.position, Quaternion.identity);
        death.Play();

        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }
}

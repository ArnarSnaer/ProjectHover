using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    private SpawnManager _spawnManager;
    public AudioSource enemyKill;
    public int max_health;
    // Start is called before the first frame update
    public HealthSystem health;
    void Start()
    {   
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        health = new HealthSystem(max_health);
        health.Ded += HealthSystem_Ded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HealthSystem_Ded(object sender, System.EventArgs e){
        Destroy(this.gameObject);
        Death();
    }
    private void Death(){
        _spawnManager.EnemyDefeated();
        enemyKill.Play();
    }
}

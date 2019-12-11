using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    private SpawnManager _spawnManager;
    public AudioClip enemyKill;
    AudioSource audioSource;
    public int max_health;
    // Start is called before the first frame update
    public HealthSystem health;
    private Material matWhite;
    private Material matDefault;
    public GameObject explosionRef;
    SpriteRenderer sr;
    void Start()
    {   
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        health = new HealthSystem(max_health);
        health.Ded += HealthSystem_Ded;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HealthSystem_Ded(object sender, System.EventArgs e){
        Death();
        Destroy(this.gameObject);
    }
    private void Death(){
        _spawnManager.EnemyDefeated();
        Instantiate(explosionRef, this.transform.position, Quaternion.identity);
        audioSource.PlayOneShot(enemyKill, 1F);
        Debug.Log("Enemy defeated!");
    }
}

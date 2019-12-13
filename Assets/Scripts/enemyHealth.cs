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
    }

    public void flash(){
        StartCoroutine(Damaged());
    }
    IEnumerator Damaged() {
        Renderer enemy_color = this.GetComponentInChildren<Renderer>();
        Color old_color = enemy_color.material.color;
        enemy_color.material.color = new Color (0.5f,0.5f,0.5f,1);
        yield return new WaitForSeconds(0.2f);
        enemy_color.material.color = old_color;
    }

    public void slowed()
    {
        StartCoroutine(freeze());
    }

    IEnumerator freeze()
    {
        Renderer enemy_color = this.GetComponentInChildren<Renderer>();
        float oldSpeed = this.GetComponent<Pathfinding.IAstarAI>().maxSpeed;
        this.GetComponent<Pathfinding.IAstarAI>().maxSpeed = 0.5f;
        // Play Ice Sound

        enemy_color.material.color = new Color (0f, 1f, 1f, 1f);
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<Pathfinding.IAstarAI>().maxSpeed = oldSpeed;
    }
}

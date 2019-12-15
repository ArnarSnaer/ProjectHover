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
    Pathfinding.IAstarAI speed;
    Renderer enemy_color;
    Color old_color;
    float oldSpeed;
    void Start()
    {   
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        health = new HealthSystem(max_health);
        health.Ded += HealthSystem_Ded;
        speed = this.GetComponent<Pathfinding.IAstarAI>();
        oldSpeed = speed.maxSpeed;
        Renderer [] enemy_colors = this.GetComponentsInChildren<Renderer>();
        enemy_color = null;
        foreach(Renderer enemy in enemy_colors){
            if(enemy.tag == "SpriteRenderer"){
                enemy_color = enemy;   
            }
        }
        old_color = enemy_color.material.color;

        audioSource = GetComponent<AudioSource>();
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
        Instantiate(explosionRef, this.transform.position, Quaternion.identity);
    }

    public void flash(){
        StartCoroutine(Damaged());
    }
    IEnumerator Damaged() {
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
        speed.maxSpeed = 0.5f;
        // Play Ice Soun
        enemy_color.material.color = new Color (0f, 1f, 1f, 1f);
        yield return new WaitForSeconds(2f);
        speed.maxSpeed = oldSpeed;
        enemy_color.material.color = old_color;
    }
}

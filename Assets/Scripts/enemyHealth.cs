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
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    SpriteRenderer sr;
    void Start()
    {   
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        health = new HealthSystem(max_health);
        health.Ded += HealthSystem_Ded;

        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;

        explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HealthSystem_Ded(object sender, System.EventArgs e){
        Death();
        enemyKill.Play();
        //GameObject explosion = (GameObject)Instantiate(explosionRef);
        //explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        Destroy(this.gameObject);
    }
    private void Death(){
        _spawnManager.EnemyDefeated();
    }

    public void flash(){
        StartCoroutine(Damaged());
    }
    IEnumerator Damaged() {
        Renderer enemy_color = this.GetComponent<Renderer>();
        Color old_color = enemy_color.material.color;
        enemy_color.material.color = new Color (0.5f,0.5f,0.5f,1);
        yield return new WaitForSeconds(0.5f);
        enemy_color.material.color = old_color;
    }
}

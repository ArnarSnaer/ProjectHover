using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAbilities : MonoBehaviour
{
    private string playerIndex;
    public float l1Cooldown;
    public float l2Cooldown;

    public bulletControler bullet;
    public bulletControler grenade;
    public bulletControler piercing_shot;
    public AudioSource piercingClip;
    public AudioSource grenadeClip;
    private Transform point;
    private Animation anim;
    public int max_piercing;
    private int piercing_shots;

    [HideInInspector]
    public float piercingCountdown;
    
    [HideInInspector]
    public float grenadeCountdown;
    

    // Start is called before the first frame update
    void Start()
    {
        playerIndex = gameObject.GetComponentInParent<TankMovement>().playerIndex;
        anim = gameObject.GetComponent<Animation>();
        piercingCountdown = 0.0f;
        grenadeCountdown = 0.0f;
        piercing_shots = max_piercing;

    }

    // Update is called once per frame
    void Update()
    {
        if (piercingCountdown > 0 || piercing_shots < max_piercing)
        {
            Debug.Log(piercing_shots);
            piercingCountdown -= Time.deltaTime;
            if (piercingCountdown < 0){
                this.piercing_shots += 1;
                piercingCountdown = l2Cooldown;
            }
        } 
        if (grenadeCountdown > 0)
        {
            grenadeCountdown -= Time.deltaTime;
            if (grenadeCountdown < 0) grenadeCountdown = 0;
        } 
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("P" + playerIndex + " L1") && piercing_shots > 0)
        {
            this.piercing_shots -= 1;
            Piercing();
        }

        if (Input.GetButtonDown("P" + playerIndex + " L2") && grenadeCountdown == 0.0f)
        {
            Grenade();
            grenadeCountdown = l2Cooldown;
        }

    }

    void Grenade()
    {
        point = this.transform.Find("GrenadeSpawn");
        bulletControler my_grenade = Instantiate(grenade, point.position, point.rotation) as bulletControler;
        grenade.speed = 15;
    }


    void Piercing()
    {
        point = this.transform.Find("GrenadeSpawn");
        bulletControler piercing = Instantiate(piercing_shot, point.position, point.rotation) as bulletControler;
        piercing.speed = 15;
    }
}

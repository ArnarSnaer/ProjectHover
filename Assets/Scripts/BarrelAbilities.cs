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
    public AudioSource piercingClip;
    public AudioSource grenadeClip;
    private Transform point;
    private Animation anim;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (piercingCountdown > 0)
        {
            piercingCountdown -= Time.deltaTime;
            if (piercingCountdown < 0) piercingCountdown = 0;
        } 
        if (grenadeCountdown > 0)
        {
            grenadeCountdown -= Time.deltaTime;
            if (grenadeCountdown < 0) grenadeCountdown = 0;
        } 
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("P" + playerIndex + " L1") && piercingCountdown == 0.0f)
        {
            Piercing();
            //Push();
            piercingCountdown = l1Cooldown;
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
    }
}

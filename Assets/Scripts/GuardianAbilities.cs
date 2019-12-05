using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbilities : MonoBehaviour
{
    private string playerIndex;
    public float pushCooldown;
    public float wallCooldown;
    public float domeCooldown;
    public float shieldTime;
    public GameObject guardianShield;
    public GameObject pushWall;
    private Transform point;
    private Animation anim;

    [HideInInspector]
    public float pushCountdown;
    
    [HideInInspector]
    public float wallCountdown;
    
    [HideInInspector]
    public float domeCountdown;

    // Start is called before the first frame update
    void Start()
    {
        playerIndex = gameObject.GetComponentInParent<TankMovement>().playerIndex;
        anim = gameObject.GetComponent<Animation>();
        pushCountdown = 0.0f;
        wallCountdown = 0.0f;
        domeCountdown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushCountdown > 0)
        {
            pushCountdown -= Time.deltaTime;
            if (pushCountdown < 0) pushCountdown = 0;
        } 
        if (wallCountdown > 0)
        {
            wallCountdown -= Time.deltaTime;
            if (wallCountdown < 0) wallCountdown = 0;
            Debug.Log(wallCountdown);
        } 
        if (domeCountdown > 0)
        {
            domeCountdown -= Time.deltaTime;
            if (domeCountdown < 0) domeCountdown = 0;
        } 
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("P" + playerIndex + " L1") && pushCountdown == 0.0f)
        {
            Push();
            pushCountdown = pushCooldown;
        }

        if (Input.GetButtonDown("P" + playerIndex + " L2") && wallCountdown == 0.0f)
        {
            PlaceWall();
            wallCountdown = wallCooldown;
        }

        if (Input.GetButtonDown("P" + playerIndex + " PS4 Circle") && domeCountdown == 0.0f)
        {
            // Not implimented
            Dome();
            domeCountdown = domeCooldown;
        }

    }

    void Push()
    {
        point = this.transform.Find("BulletSpawn");
        GameObject push = Instantiate(pushWall, point.position, point.rotation) as GameObject;
        Destroy(push, 0.28f);
    }

    void PlaceWall()
    {
        point = this.transform.Find("WallSpawn");
        GameObject shield = Instantiate(guardianShield, point.position, point.rotation) as GameObject;
        Destroy(shield, shieldTime);
    }

    void Dome()
    {
        // Spawns a dome around the player which will block enemies
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAbilities : MonoBehaviour
{
    private string playerIndex;
    public float pushCooldown;
    public float placeWallCooldown;
    public float domeCooldown;
    public float shieldTime;
    public GameObject guardianShield;
    public GameObject pushWall;
    private Transform point;

    private float pushCountdown;
    private float wallCountdown;
    private float domeCountdown;

    // Start is called before the first frame update
    void Start()
    {
        playerIndex = gameObject.GetComponentInParent<TankMovement>().playerIndex;
        pushCountdown = 0;
        wallCountdown = 0;
        domeCountdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushCountdown > 0)
        {
            pushCountdown -= 1;
            if (pushCountdown < 0) pushCountdown = 0;
        } 
        if (wallCountdown < 0)
        {
            wallCountdown -= 1;
            if (wallCountdown < 0) wallCountdown = 0;
        } 
        if (domeCountdown < 0)
        {
            domeCountdown -= 1;
            if (domeCountdown < 0) domeCountdown = 0;
        } 
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("P" + playerIndex + " PS4 Square"))
        {
            Debug.Log("Square!");
            Push();
            pushCountdown = pushCooldown;
        }

        else if (Input.GetButtonDown("P" + playerIndex + " PS4 Triangle"))
        {
            Debug.Log("Triangle!");
            PlaceWall();
            wallCountdown = placeWallCooldown;
        }

        else if (Input.GetButtonDown("P" + playerIndex + " PS4 Circle"))
        {
            Debug.Log("Circle!");
            Dome();
            domeCountdown = domeCooldown;
        }

    }

    void Push()
    {
        point = this.transform.Find("BulletSpawn");
        Debug.Log(point);
        GameObject push = Instantiate(pushWall, point.position, point.rotation) as GameObject;
        push.transform.Translate(push.transform.up * 100 * Time.deltaTime);
        Destroy(push, 2);
    }

    void PlaceWall()
    {
        point = this.transform.Find("WallSpawn");
        Debug.Log(point);
        GameObject shield = Instantiate(guardianShield, point.position, point.rotation) as GameObject;
        Destroy(shield, shieldTime);
    }

    void Dome()
    {

    }
}

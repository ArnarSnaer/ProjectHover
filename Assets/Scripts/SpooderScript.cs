using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpooderScript : MonoBehaviour
{
    public GameObject spooder_web;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D enemy){
        if(enemy != null){
            if(enemy.gameObject.GetComponent<TankMovement>() != null){
                TankMovement tank = enemy.gameObject.GetComponent<TankMovement>();
                tank.moveSpeed = 0;
                Transform point = tank.gameObject.transform;
                string player_index = tank.playerIndex;
                GameObject web = Instantiate(spooder_web, point.position, Quaternion.Euler(point.rotation.x, point.rotation.y, point.eulerAngles.z + 180)) as GameObject;
                web.GetComponent<WebPhysics>().player_index = player_index;
            }
        }
    }
}

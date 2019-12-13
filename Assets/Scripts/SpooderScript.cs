using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpooderScript : MonoBehaviour
{
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
            }
        }
    }
}

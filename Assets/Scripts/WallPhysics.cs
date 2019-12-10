using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
        Debug.Log("HIT");
        if(enemy.gameObject.tag == "enemy"){
            Debug.Log("Found Enemy!");
            Vector3 dir = enemy.transform.position - enemy.transform.position;
            dir.Normalize();
            float strength = 2f;
            this.transform.GetComponent<Rigidbody>().AddForce(dir * strength, ForceMode.Impulse);
        }
    }
    }
}

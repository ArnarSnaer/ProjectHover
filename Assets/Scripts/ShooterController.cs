using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    // Start is called before the first frame update
    private float min_distance = 5.0f;
    Pathfinding.IAstarAI ai_star;
    private float base_speed;
    private Transform target;
    void Start()
    {
        StartCoroutine(LateStart());

    }

    // Update is called once per frame
    void Update()
    {
        float dis=Vector3.Distance(this.transform.position, target.position);
    	if(dis<=min_distance){
            ai_star.maxSpeed = 0;
        }
        else{
            ai_star.maxSpeed = base_speed;
        }
    }
 
     IEnumerator LateStart()
     {
         yield return new WaitForSeconds(0.5f);
        Pathfinding.AIDestinationSetter ai_destination = this.GetComponent<Pathfinding.AIDestinationSetter>();
        target = ai_destination.target;
        ai_star = this.GetComponent<Pathfinding.IAstarAI>();
        base_speed = ai_star.maxSpeed;
     }
}

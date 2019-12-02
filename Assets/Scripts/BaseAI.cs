using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public TankMovement player;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<TankMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Finding Player
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }


    void OnCollisionEnter2D(Collision2D enemy){
    if(enemy != null){
            Destroy (this.gameObject);
            Destroy (enemy.gameObject);
        }
    }

    
}

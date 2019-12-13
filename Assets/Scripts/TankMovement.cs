using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public string playerIndex;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private float angle;
    private float deadzone = 0.04f;
    public Rigidbody2D summer_body;

    // Start is called before the first frame update
    void Start()
    {
        summer_body = this.GetComponent<Rigidbody2D>();
        summer_body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving object with left analog stick
        moveInput = new Vector2(Input.GetAxis("P" + playerIndex + " Horizontal"), Input.GetAxis("P" + playerIndex + " Vertical"));
        moveVelocity = moveInput * moveSpeed;

        // Rotating object with right analog stick
        float horizontal = Input.GetAxisRaw("P" + playerIndex + " RHorizontal");
        float vertical = Input.GetAxisRaw("P" + playerIndex + " RVertical");
        Vector2 RmoveInput = new Vector2(horizontal, vertical);

        if (horizontal != 0 && vertical != 0 && RmoveInput.magnitude > deadzone)
        // User is pressing the analog stick and is not within the deadzone.
        {
            angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        }
                
    }

    void FixedUpdate()
    {
        rb.rotation = angle;
        rb.velocity = moveVelocity;
    }
    public void player_flash(){
        StartCoroutine(Damaged());
    }
    public IEnumerator Damaged() {
        Renderer enemy_color = this.GetComponent<Renderer>();
        Color old_color = enemy_color.material.color;
        enemy_color.material.color = new Color (1,0,0,1);
        yield return new WaitForSeconds(0.5f);
        enemy_color.material.color = old_color;
    }
}

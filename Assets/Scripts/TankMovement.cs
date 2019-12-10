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
    private float deadzone = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Moving object with left analog stick
        moveInput = new Vector2(Input.GetAxisRaw("P" + playerIndex + " Horizontal"), Input.GetAxisRaw("P" + playerIndex + " Vertical"));
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
}

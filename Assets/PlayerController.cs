using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //how fast the character moves
    public float jumpHeight; //how high the character jumps
    public KeyCode Spacebar; //the jump button
    public KeyCode L; //the left movement button
    public KeyCode R; //the right movement button

    public Transform groundCheck; //an invisible point at the player's feet
    public float groundCheckRadius; //how big the circle around the feet is
    public LayerMask whatIsGround; //what counts as ground
    private bool grounded; //is the character standing on ground

    private Animator anim; //the player's Animator

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded) //When user presses the space button ONCE
        {
            Jump();
        }

        if (Input.GetKey(L)) //When user presses the left arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R)) //When user presses the right arrow button
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Grounded", grounded);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
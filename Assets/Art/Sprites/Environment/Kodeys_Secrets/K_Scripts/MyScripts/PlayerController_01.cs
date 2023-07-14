using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_01 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private int extraJumps; 
    public int extraJumpsValue;

    private Rigidbody2D rb;
    private Animator animate;

    private bool facingRight = true;

    private float isJumping; ///
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animate=gameObject.GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        animate.SetFloat("Speed", Mathf.Abs(moveInput)); //"moveInput" is what triggers movement 

        if(facingRight == true && moveInput > 0)
        {
            Flip();
        }
        
        else if(facingRight == false && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1; 
        transform.localScale = Scaler;
    }

    void Update()
    {

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animate.SetFloat("isJumping", Mathf.Abs(jumpForce));////
            
        }
        
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

            
        }
    }
}



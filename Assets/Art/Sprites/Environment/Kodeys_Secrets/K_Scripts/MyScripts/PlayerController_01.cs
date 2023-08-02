using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unravel.Touch;

public class PlayerController_01 : MonoBehaviour,
    IPubAccess<TouchEvent>
{
/********** Data **********/
    [SerializeField]
    private bool connectToHub = false;
    private Hub hub;

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

/********** Constuction **********/
    void Awake()
    {
        if(this.connectToHub)
            this.hub = GameObject.FindWithTag("Hub").GetComponent<Hub>();
    }
    
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animate=gameObject.GetComponent<Animator>();

        if(this.connectToHub)
            this.hub.getTouchSubAccess().subscribe(this);
    }
/********** Runtime **********/
    void Update()
    {

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
            this.aerialJump();
        
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
            this.jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0.0f)
            this.updateMoveInput(horizontal);

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        animate.SetFloat("Speed", Mathf.Abs(moveInput)); //"moveInput" is what triggers movement 

        if(facingRight == true && moveInput > 0)
            this.flip();
        
        else if(facingRight == false && moveInput < 0)
            this.flip();

    }
/********** Actions **********/
    private void updateMoveInput(float power)
    {
        this.moveInput = power;
    }
    private void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1; 
        transform.localScale = Scaler;
    }
    
    private void aerialJump()
    {
        this.jump();
        extraJumps--;
        animate.SetFloat("isJumping", Mathf.Abs(jumpForce));////
    }

    private void jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

/********** Touch Events **********/  
    public void publishEvent(TouchEvent e)
    {
        //UnityEngine.Debug.Log(e.gesture);
        switch(e.gesture)
        {
            case GESTURE.TAP:
                this.evaluateDirection(e.screenPos);
                break;
            case GESTURE.HOLD:
                this.evaluateDirection(e.screenPos);
                break;
            case GESTURE.MOVED:
                this.evaluateDirection(e.screenPos);
                break;
            case GESTURE.RELEASE:
                this.updateMoveInput(0.0f);
                break;
            default:
                break;
        }
    }

    private void evaluateDirection(SCREEN_POS screenPos)
    {
        if(screenPos == SCREEN_POS.RIGHT)
            this.updateMoveInput(1.0f);
        else if(screenPos == SCREEN_POS.LEFT)
            this.updateMoveInput(-1.0f);
    }

/********** Clean Up **********/
    void OnDestroy()
    {
        if(this.connectToHub)
            this.hub.getTouchSubAccess().unsubscribe(this);
    }
}  



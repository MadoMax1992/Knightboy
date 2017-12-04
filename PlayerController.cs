using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runTopSpeed;
    public float gravityMulti = 2.5f;
    public float lowGravityMulti = 2f;
    public float jumpVelo;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public static int currenthealth;

    [HideInInspector]
    public float move;
    
    private float groundRadius = 0.1f;
    private bool grounded = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public AudioSource auSc;
    


    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        auSc = GetComponent<AudioSource>();
       
        
    }





    void Update()
    {
        currenthealth = HealthController.currentHealth;

        
        if (currenthealth>=1)
        {
            move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * runTopSpeed, rb.velocity.y);

        }
        


       

        if (Input.GetButtonDown("Jump")&& grounded)
        {
            animator.SetBool("jumping", false);
        
            jump();
        }
        animator.SetFloat("vSpeed", rb.velocity.y);

        if (Input.GetKey("escape"))
            Application.Quit();


        superMarioJumpApplier();
        
            flipDirection(move);
        
        
        animateWalking(move);
        groundChecking();

    }

    public void superMarioJumpApplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (gravityMulti - 1) * Time.deltaTime;

        }
        else if (!Input.GetButton("Jump") && rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowGravityMulti - 1) * Time.deltaTime;

        }
    }

    public void groundChecking()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded == false)
        {
            animator.SetBool("jumping", true);

        }
        else if (grounded == true)
        {
            animator.SetBool("jumping", false);
        }
    }
    public void jump()
    {
        rb.velocity = Vector2.up * jumpVelo;
        auSc.Play();
    }
   
    private void animateWalking(float move)
    {
        if (move != 0 && (grounded==true))
        {
            animator.SetBool("walking", true);
            
        }
        else
        {
            animator.SetBool("walking", false);

        }
        
    }


    private void flipDirection(float move)
    {
        
            if (move < -0.01f)
            {
                spriteRenderer.flipX = true;

            }
            if (move > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
        
        
    }

   






}

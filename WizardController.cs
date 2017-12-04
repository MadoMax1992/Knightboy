using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardController : MonoBehaviour {
    
    public GameObject fireBall;
    public float health;
    public float speed;
   
    private Animator anim;
    private SpriteRenderer spR;
    private bool alive = true;
    [HideInInspector]
    public static bool isRight= true;
    private Rigidbody2D rb2D;
    private bool isHit = false;
    public static bool wizardDead;
    private Collider2D col;
 
    

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spR = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        StartCoroutine("FightRoutine");
        wizardDead = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if ((health<=0) && alive)
        {
            alive = false;
            StartCoroutine("dieRoutine");
            
        }
        isHit = false;
    }

    private IEnumerator FightRoutine()
    {
        yield return new WaitForSeconds(3f);

        while (!wizardDead)
        {
            shootFireball();
            yield return new WaitForSeconds(1.5f);
            shootFireball();
            yield return new WaitForSeconds(1.5f);
            shootFireball();
            yield return new WaitForSeconds(3f);
            dash();
            yield return new WaitForSeconds(4f);
        }

        



        StopCoroutine("FightController");
    }

    void shootFireball()
    {
        
        if (isRight)
        {
            Instantiate(fireBall, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);

        }
        else
        {
            Instantiate(fireBall, new Vector3(transform.position.x + 0.4f, transform.position.y - 0.2f, transform.position.z), Quaternion.identity);
        }
    }

    void dash()
    {
        StartCoroutine("Dash");
    }
    private IEnumerator Dash()
    {
        
        if (isRight)
        {
            
            anim.SetBool("isDashing", true);
            rb2D.velocity = new Vector2(-1 * speed, rb2D.velocity.y);
            
            yield return new WaitForSeconds(2f);
            isRight = false;
            anim.SetBool("isDashing", false);
            spR.flipX = true;
        }
        else
        {
            anim.SetBool("isDashing", true);
            rb2D.velocity = new Vector2(1 * speed, rb2D.velocity.y);
            yield return new WaitForSeconds(2f);
            isRight = true;
            anim.SetBool("isDashing", false);
            spR.flipX = false;
        }

        StopCoroutine("MoveLeft");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
        {
            return;
        }
        isHit = true;
        if (collision.CompareTag("Sword"))
        {
            health--;

            if (health==0)
            {
                Physics2D.IgnoreCollision(collision, col);
                anim.SetTrigger("isDead");
            }
            else
            {
                anim.SetTrigger("isHurt");
            }
            
                

            
            
           
                              
                      
        }
    }

    private IEnumerator dieRoutine()
    {

        //start Animation
        yield return new WaitForSeconds(1.5f);
        wizardDead = true;
        yield return new WaitForSeconds(3f);          //Suffer
        Destroy(gameObject);
        StopCoroutine("dieRoutine");
    }




}

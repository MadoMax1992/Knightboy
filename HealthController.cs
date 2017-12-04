using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    private int maxhealth= 3;
    private Animator anim;
    private Rigidbody2D rb;
    private Collider2D bc2d;
    public static int currentHealth;
    public static bool wizardDead;
    public Text winText;
    
    

    
    
    private bool isHit;
    

    // Use this for initialization
    void Start () {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        bc2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
       
        
        winText.text = "";
        

        currentHealth = maxhealth;
    }
	
	// Update is called once per frame
	void Update () {

        wizardDead = WizardController.wizardDead;

        if (wizardDead)
        {
            winText.text = "You Won";
        }
        else if (currentHealth==0)
        {
            winText.text = "You Died";
        }
        
        isHit = false;
        
       
	}
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
        {
            return;
        }
        
        isHit = true;
        if (collision.CompareTag("Enemy")&&!wizardDead)
        {
            
            currentHealth--;
            if (currentHealth!=0)
            {
                anim.SetTrigger("isHurt");
                
            }
            else if (currentHealth==0)
            {
                StartCoroutine("dieRoutine");
            }

            Physics2D.IgnoreCollision(collision, bc2d);

        }
       


    }
   

    private IEnumerator dieRoutine()
    {

        anim.SetTrigger("isDead");
        
        
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        
       
        

        yield return new WaitForSeconds(4f);          //Suffer
        SceneManager.LoadScene("Main");
        StopCoroutine("dieRoutine");
    }


    




}

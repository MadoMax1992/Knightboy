using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {
    private Rigidbody2D rb;
    public float topSpeed;
    private int direction = -1;
    private static bool isRight;
    private SpriteRenderer spR;
    private static bool wizardDead;
    

	// Use this for initialization
	void Start () {
        
        rb = GetComponent<Rigidbody2D>();
        isRight = WizardController.isRight;
        spR = GetComponent<SpriteRenderer>();
       
	}
	
	// Update is called once per frame
	void Update () {
        wizardDead = WizardController.wizardDead;
        if (wizardDead)
        {
            Destroy(gameObject);
        }
        if (isRight==false)
        {
            spR.flipX = true;
            direction = 1;
        }
        else
        {
            spR.flipX = false;
            direction = -1;
        }
        rb.velocity = new Vector2(direction * topSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Sword") || collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }  
}

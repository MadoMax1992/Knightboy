using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour {

    public float topSpeed;
    

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D bc2d;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        
        
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(-1 * topSpeed, rb.velocity.y);


      
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            StartCoroutine("dieRoutine");

        }
    }



    private IEnumerator dieRoutine()
    {

        anim.SetTrigger("isHurt");                      //start Animation
        bc2d.enabled = false;                           //everthing can pass while dying
        rb.gravityScale = 0;                            //Dont fall through the ground
        topSpeed = 0;                                     //stop moving
        yield return new WaitForSeconds(0.8f);          //Suffer
        Destroy(gameObject);
        StopCoroutine("dieRoutine");
    }


}

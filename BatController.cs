using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour{


    public Transform player;
    public float velocity;
    public float range = 8;
    private Animator anim;
    private bool inRange = false;

    private SpriteRenderer sprRen;
    private bool lookLeft = true;
    private BoxCollider2D bc2d;


    

    // Use this for initialization
    void Start(){
        anim = GetComponent<Animator>();
        sprRen = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     


       

        if (Vector2.Distance(transform.position, player.position) <= range)
        {
            Debug.DrawLine(player.position, transform.position, Color.yellow);
            anim.SetTrigger("inRange");
            inRange = true;
            

           

        }

        if (inRange)
        {
            followPlayer();
        }
    }

    private void followPlayer() {
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * velocity, localPosition.y * Time.deltaTime * velocity, localPosition.z * Time.deltaTime * velocity);


        if (localPosition.x >= 0 && (lookLeft ==true))
        {
            sprRen.flipX = true;
            lookLeft = false;
        }
        if (localPosition.x < 0 && (lookLeft==false))
        {
            sprRen.flipX = false;
            lookLeft = true;
        }
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
        velocity = 0;                                     //stop moving
        yield return new WaitForSeconds(0.8f);          //Suffer
        Destroy(gameObject);
        StopCoroutine("dieRoutine");
    }
}

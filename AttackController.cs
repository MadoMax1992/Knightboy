using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    public Collider2D attackTrigger;
    private Animator anim;
    private bool attacking = false;
    private float attackTimer = 0f;
    public float attackCd;
    public AudioSource auSc;


    void Awake()
    {
        attackTrigger.enabled = false;        
    }

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        auSc = GetComponent<AudioSource>();
    }   

    void Update () {

        if (Input.GetButtonDown("Fire1") && !attacking )
        {
            auSc.Play();

            if (Input.GetKey("up"))
            {
                anim.Play("UpStab");
                AttackEnabler(true);
                attackTimer = attackCd;
            }
            else
            {
                anim.Play("Attack");
                AttackEnabler(true);
                attackTimer = attackCd;
            }
        }

       
      

        if (attacking)
        {
            if (attackTimer>0)
            {
                attackTimer = attackTimer - Time.deltaTime;

            }
            else
            {
                AttackEnabler(false);
            }

        }
        else
        {
            AttackEnabler(false);
        }







        SwordTurning();

    }

    

    private void AttackEnabler(bool state)
    {
        attacking = state;
        anim.SetBool("attacking", state);
        attackTrigger.enabled = state;
    }


    private void SwordTurning()
    {
        float moveDir = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().move;

        if ((moveDir) < 0)
        {
            transform.localPosition = new Vector2(-0.24f, 0);
        }
        else if ((moveDir) > 0)
        {
            transform.localPosition = new Vector2(0.24f, 0);

        }
    }
}

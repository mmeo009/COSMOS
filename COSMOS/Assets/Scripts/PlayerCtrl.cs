using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public GameManager GM;

   

    public AudioClip shoutClip, jumpClip, dashClip, getDmg;
    private AudioSource audioSource;
    public float jumpForce = 5.324f;
    public int jumpCount = 0;
    private bool isTouchingGround;
    public LayerMask groundLayer;

    public int HP = 5;
    private bool wait = false;
    public float hpTimer = 1.0f;

    public Collider2D[] enemies;
    public float shoutTimer = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if(shoutTimer >= 0)
        {
            shoutTimer -= Time.fixedDeltaTime;
            this.GetComponent<HP>().UpdateShoutBar();
        }
        anim.SetFloat("Speed", GM.speed + 1);

        if(this.transform.position.y <= -7)
        {
            GetDMG(5);
        }

        if(wait == true)
        {
            hpTimer -= Time.fixedDeltaTime;
        }
        if(hpTimer <= 0)
        {
            wait = false;
            hpTimer = 1.0f;
        }
    }

    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(this.transform.position, 1.8f, groundLayer);

        if(Input.GetButtonDown("Jump")&& jumpCount <= 4)
        {
            Jump();
        }

        //anim.SetBool("IsGrounded", isTouchingGround);

        if (isTouchingGround == true)
        {
            //anim.SetBool("jump", false);
            jumpCount = 0;
        }


        if (Input.GetKeyDown(KeyCode.D)) //���X���X
        {
            if (GM.dash == false)
            {
                GM.dash = true;
                audioSource.PlayOneShot(dashClip);
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            if(shoutTimer <= 0)
            {
                Shout();
            }
        }
    }
    
    private void Jump()
    {
        jumpCount++;
        rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        //anim.SetTrigger("Jump");
        audioSource.PlayOneShot(jumpClip);
    }
    private void Shout()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, 8f);
        foreach (Collider2D coll in enemies)
        {
            if (coll.gameObject.tag == "Monster" || coll.gameObject.tag == "Obstacle")
            {
                coll.GetComponent<EnemyCtrl>().Defeat();
            }
        }
        audioSource.PlayOneShot(shoutClip);
        shoutTimer = 1.5f;
    }
    public void GetDMG(int dmg)
    {
        audioSource.PlayOneShot(getDmg);
        if(wait == false)
        {
            HP -= dmg;
            wait = true;
        }
        this.GetComponent<HP>().currentHP = HP;
        this.GetComponent<HP>().UpdateHPBar();
        if (HP <= 0)
        {
            GM.GameOver();
        }
    }
}

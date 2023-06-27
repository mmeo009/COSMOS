using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public GameManager GM;

    public AudioClip shoutClip, jumpClip, dashClip;
    private AudioSource audioSource;
    public float jumpForce = 5.324f;
    public int jumpCount = 0;
    private bool isTouchingGround;
    public LayerMask groundLayer;

    public int HP = 5;

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
        shoutTimer -= Time.fixedDeltaTime;
        anim.SetFloat("Speed", GM.speed + 1);

        if(this.transform.position.y <= -7)
        {
            GetDMG(5);
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


        if (Input.GetKeyDown(KeyCode.D)) //À¸›XÀ¸›X
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
            if (coll.gameObject.tag == "Monster")
            {
                coll.GetComponent<EnemyCtrl>().Defeat();
            }
        }
        audioSource.PlayOneShot(shoutClip);
        shoutTimer = 1.5f;
    }
    public void GetDMG(int dmg)
    {
        audioSource.PlayOneShot(shoutClip);
        HP -= dmg;
        Debug.Log(HP);
        if(HP <= 0)
        {
            GM.GameOver();
        }
    }
}

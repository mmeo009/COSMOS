using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public GameManager GM;
    public float jumpForce = 4f;
    public float rayDistance = 2f;
    //public float jumpSpeed = 8f;
    public bool isJumping = false;


    public Transform groundCheck;
    private bool isTouchingGround;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    
 
    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
     

        Vector2 rayOrigin = transform.position;
        Vector2 rayEnd = rayOrigin + new Vector2(0f, -rayDistance);
        // Ray를 그리기
        Debug.DrawLine(rayOrigin, rayEnd, Color.magenta);
        if (Input.GetKeyDown(KeyCode.Space)) //점프
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayDistance);
            if (hit.collider != null && hit.collider.CompareTag("Ground"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Debug.DrawLine(rayOrigin, hit.point, Color.green);
                Debug.Log(hit.collider.gameObject.name);
            }
        }

        if(Input.GetButtonDown("Jump")&& !isJumping )
        {
            Jump();
        }

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        anim.SetBool("IsGrounded", isGrounded);



        if(Input.GetKeyDown(KeyCode.D))
        {
            if (GM.dash == false)
            {
                GM.dash = true;
            }
        }


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isTouchingGround == false)
        {
            anim.SetBool("jump", true);
        }

        if (isTouchingGround == true)
        {
            anim.SetBool("jump", false);
        }







    }
    
    private void Jump()
    {
        isJumping = true;
        rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        anim.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅과 충돌감지
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}

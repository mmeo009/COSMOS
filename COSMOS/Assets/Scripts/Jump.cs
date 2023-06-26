using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float maxSpeed;// �ִ�ӵ� ����
    public float jumpPower; // �����Ŀ� 
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // �̸��� �����Ѵ� !
            anim.SetBool("isJumping", true);
        }
        // Stop Speed 
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float���Ҷ��� f�ٿ�����Ѵ�.

        }

        // change Direction
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        // work animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3) //���� ���� 
            anim.SetBool("isWorking", false);
        else
            anim.SetBool("isWorking", true);

    }


    void FixedUpdate()
    {
        // Move by Control
        float h = Input.GetAxisRaw("Horizontal"); // Ⱦ���� Ű�� ������ 
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // �̸��� �̵��Ѵ� !


        // MaxSpeed Limit
        if (rigid.velocity.x > maxSpeed)// right
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Maxspeed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        // Lending Platform
        if (rigid.velocity.y < 0)
        {
            //Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0)); //������ �󿡼��� ���̸� �׷��ش�
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null) // �ٴ� ������ ���ؼ� �������� ���! 
            {
                if (rayHit.distance < 0.5f)
                {
                    anim.SetBool("isJumping", false);
                }
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpw : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // 키보드에서 손을 뗐을 때 완전 stop -->멈출 때 속도 
    private void Update() //즉각적인 키 입력 ,단발적인 키 입력
    {

        //점프

        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        }

    }
}

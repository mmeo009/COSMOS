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

    // Ű���忡�� ���� ���� �� ���� stop -->���� �� �ӵ� 
    private void Update() //�ﰢ���� Ű �Է� ,�ܹ����� Ű �Է�
    {

        //����

        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        }

    }
}

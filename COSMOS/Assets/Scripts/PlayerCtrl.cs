using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public GameManager GM;
    public float jumpForce = 4f;
    public float rayDistance = 2f;
    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
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

        if(Input.GetKeyDown(KeyCode.D))
        {
            if (GM.dash == false)
            {
                GM.dash = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float normalSpeed = 0.01f;
    public float speed;
    public float dashTimer = 1.0f;
    public bool dash = false;
    public bool isJumping = false;

    private void Awake()
    {
        dash = false;
    }
    private void Update()
    {
        normalSpeed += 0.01f * Time.deltaTime;
        if(dash == false)
        {
            speed = normalSpeed;
        }
        else
        {
            speed += 1 * Time.deltaTime;
            dashTimer -= Time.deltaTime;
            if(dashTimer <= 0)
            {
                dash = false;
                dashTimer = 1.0f;
            }
        }

    }

    public void GameOver()
    {
        // 게임오버
    }
}

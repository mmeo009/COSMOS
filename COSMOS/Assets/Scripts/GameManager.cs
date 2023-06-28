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
    public static GameManager Instance;
    private bool isGameOver = false;

    private void Awake()
    {
        dash = false;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over");
            Application.Quit();
        }
    }

}

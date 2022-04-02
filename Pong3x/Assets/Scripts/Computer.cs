using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Paddle
{
    GameManager gameManager;
    Rigidbody2D ball;
    BallSpawner ballSpawner;
    Rigidbody2D myrb;    
    private void Awake()
    {      
        gameManager = FindObjectOfType<GameManager>();
        SetBall();
        myrb = GetComponent<Rigidbody2D>();
        //  ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
    }
    void Start()
    {
        gameManager.isSinglePlayer = true;
    }

    void FixedUpdate()
    {
        ComputerPaddleAI();
    }

    private void SetBall()
    {
        ball = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
    }

    void ComputerPaddleAI()
    {
        if (ball != null)
        {
            if (ball.velocity.x > 0.0f)
            {
                Debug.Log("1");
                if (ball.position.y > this.transform.position.y)
                {
                    Debug.Log("2");
                    this.myrb.velocity = Vector2.up * this.Speed * Time.deltaTime;
                }
                else if (ball.position.y < this.transform.position.y)
                {
                    Debug.Log("3");
                    this.myrb.velocity = Vector2.down * this.Speed * Time.deltaTime;
                }
            }
            else
            {
                if (transform.position.y > 1.1f)
                {
                    Debug.Log("5");
                    this.myrb.velocity = Vector2.down * this.Speed * Time.deltaTime;
                }
                else if (transform.position.y < -1.1f)
                {
                    Debug.Log("6");
                    this.myrb.velocity = Vector2.up * this.Speed * Time.deltaTime;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Paddle
{
    Rigidbody2D ball;
    BallSpawner ballSpawner;
    private void Awake()
    {
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
    }

    void FixedUpdate()
    {
        ComputerPaddleAI();
        if (ballSpawner.SetInstanceBall() != null)
        {
            ball = ballSpawner.SetInstanceBall().GetComponent<Rigidbody2D>();
        }
    }

    void ComputerPaddleAI()
    {
        if (ball != null)
        {
            if (ball.velocity.x > 0.0f)
            {
                Debug.Log("1");
                if (ball.position.y > transform.position.y && ball != null)
                {
                    Debug.Log("2");
                    _rigidbody.velocity = Vector2.up * Speed * Time.deltaTime;
                }
                else if (ball.position.y < transform.position.y && ball != null)
                {
                    Debug.Log("3");
                    _rigidbody.velocity = Vector2.down * Speed * Time.deltaTime;
                }
            }
            else
            {
                if (transform.position.y > 0.0f && ball != null)
                {
                    Debug.Log("5");
                    _rigidbody.velocity = Vector2.down * Speed * Time.deltaTime;
                }
                else if (transform.position.y < 0.0f && ball != null)
                {
                    Debug.Log("6");
                    _rigidbody.velocity = Vector2.up * Speed * Time.deltaTime;
                }
            }
        }
    }
}

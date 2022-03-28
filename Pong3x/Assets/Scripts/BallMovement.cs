using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    BallSpawner ballSpawner;
    [SerializeField] float ballSpeed = 200f;
    Rigidbody2D ballRigidBody;
    Vector2 ballDirection;
    [SerializeField] Sprite ballSprite;

    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
        StartMovement();
    }

    void FixedUpdate()
    {
        ballRigidBody.velocity = ballDirection * ballSpeed;
    }
    void StartMovement()
    {    
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f):
                                    Random.Range(0.5f, 1.0f);
        
        ballDirection = new Vector2(x, y);
        ballRigidBody.velocity = ballDirection * ballSpeed;
        ballRigidBody.AddForce(ballDirection * ballSpeed);

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ballDirection.x = -ballDirection.x;
        }
        else if(other.gameObject.tag == "Wall")
        {
            ballDirection.y = -ballDirection.y;
        }
        else if(other.gameObject.tag == "EndWall")
        {
            ballSpawner.isBallAlive = false;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    BallSpawner ballSpawner;
    [SerializeField] float ballSpeed = 30f;
    Rigidbody2D ballRigidBody;
    Vector2 ballDirection;

    Vector2 minBounds;
    Vector2 maxBounds;
    
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballDirection = new Vector2(Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f));
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
    }

    void FixedUpdate()
    {
        ballRigidBody.velocity = ballDirection * ballSpeed;
    }
    void StartMovement()
    {
        ballDirection = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
        ballRigidBody.velocity = ballDirection * ballSpeed;
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

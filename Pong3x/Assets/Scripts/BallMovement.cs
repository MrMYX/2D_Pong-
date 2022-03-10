using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    BallSpawner ballSpawner;
    [SerializeField] float ballSpeed = 30f;
    Rigidbody2D ballRigidBody;
    Vector2 ballDirection;


    public Vector2 RandomVector2(float angle, float angleMax, float angleMin)
    {
        float posMin = Mathf.Sign(Random.Range(-1,1));
        float random = angleMax - Random.value * angle * posMin + angleMin;
        float random1 = angleMax - Random.value * angle * posMin + angleMin;
        return new Vector2(Mathf.Cos(random), Mathf.Sin(random1));
    }

    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballDirection = RandomVector2(7f, 35f, 5);
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

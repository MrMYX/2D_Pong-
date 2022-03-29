using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    BallSpawner ballSpawner;
    Transform ballTransform;
    Transform ballStartPoint;
    [SerializeField] float ballSpeed = 200f;
    Rigidbody2D ballRigidBody;
    Vector2 ballDirection;
    [SerializeField] Sprite ballSprite;
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        ballTransform = GetComponent<Transform>(); 
        ballRigidBody = GetComponent<Rigidbody2D>();
        ballSpawner = GameObject.Find("BallSpawner").GetComponent<BallSpawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        SetStartMovement();
    }

    void FixedUpdate()
    {
        ballRigidBody.velocity = ballDirection * ballSpeed;
    }
    void SetStartMovement()
    {    
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f):
                                    Random.Range(0.5f, 1.0f);

        ballDirection = new Vector2(x, y);
        ballRigidBody.velocity = ballDirection * ballSpeed;
        //ballRigidBody.AddForce(ballDirection * ballSpeed);

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
        if(other.gameObject.tag == "EndWall")
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        ballSpawner.isBallAlive = false;
        this.spriteRenderer.enabled = false;
        StartCoroutine(SetNewBall());
    }

    void SetStartPoint()
    {
        this.gameObject.transform.position = ballSpawner.transform.position;
    }
    IEnumerator SetNewBall()
    {
        yield return new WaitForSeconds(1.5f);
        ballSpawner.isBallAlive = true;
        SetStartPoint();
        this.spriteRenderer.enabled = true;
        SetStartMovement();
    }
}
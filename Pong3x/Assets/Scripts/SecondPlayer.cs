using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondPlayer : Paddle
{
    Vector2 moveInput;
    public Transform boundaries;

    Boundary playerBoundary;

    struct Boundary
    {
        public float Up, Down, Left, Right;
        public Boundary(float up, float down, float left, float right)
        {
            Up = up; Down = down; Left = left; Right = right;
 
        }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerBoundary = new Boundary(boundaries.GetChild(0).position.y,
                                      boundaries.GetChild(1).position.y,
                                      boundaries.GetChild(2).position.x,
                                      boundaries.GetChild(3).position.x);
    }

    void Update()
    {
        SecondPlayerUpDown();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void SecondPlayerUpDown()
    {
        Vector2 secondPlayerVelocity = new Vector2(_rigidbody.velocity.x, moveInput.y * Speed);
        _rigidbody.velocity = secondPlayerVelocity;

        Vector2 clampedSecondPlayer = new Vector2(Mathf.Clamp(transform.position.x, 
                                                             playerBoundary.Left,
                                                             playerBoundary.Right), 
                                                 Mathf.Clamp(transform.position.y, 
                                                             playerBoundary.Down, 
                                                             playerBoundary.Up));
        transform.position = clampedSecondPlayer;
    }
}

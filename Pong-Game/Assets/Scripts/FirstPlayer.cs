using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPlayer : Paddle
{

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
    Vector2 moveInput;

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
        FirstPlayerUpDown();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void FirstPlayerUpDown()
    {
        Vector3 firstPlayerVelocity = new Vector2(_rigidbody.velocity.y, moveInput.y * Speed);
        _rigidbody.velocity = firstPlayerVelocity;

        Vector2 clampedFirstPlayer = new Vector2(Mathf.Clamp(transform.position.x,
                                                             playerBoundary.Left,
                                                             playerBoundary.Right),
                                                 Mathf.Clamp(transform.position.y,
                                                             playerBoundary.Down,
                                                             playerBoundary.Up));
        transform.position = clampedFirstPlayer;
    }
}

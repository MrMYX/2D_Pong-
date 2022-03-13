using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPlayer : MonoBehaviour
{
    Rigidbody2D myRigidBody;
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
    [SerializeField] float playerSpeed = 5f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

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
        Vector3 firstPlayerVelocity = new Vector2(myRigidBody.velocity.y, moveInput.y * playerSpeed);
        myRigidBody.velocity = firstPlayerVelocity;

        Vector2 clampedFirstPlayer = new Vector2(Mathf.Clamp(transform.position.x, 
                                                             playerBoundary.Left,
                                                             playerBoundary.Right), 
                                                 Mathf.Clamp(transform.position.y, 
                                                             playerBoundary.Down, 
                                                             playerBoundary.Up));
        transform.position = clampedFirstPlayer;
    }
}

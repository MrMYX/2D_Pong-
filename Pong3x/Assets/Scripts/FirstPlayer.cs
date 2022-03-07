using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPlayer : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    Vector2 moveInput;
    [SerializeField] float playerSpeed = 5f;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
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
        Vector2 firstPlayerVelocity = new Vector2(myRigidBody.velocity.x, moveInput.y * playerSpeed);
        myRigidBody.velocity = firstPlayerVelocity;
    }
}

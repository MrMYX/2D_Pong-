using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SecondPlayer : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float secondPlayerMoveSpeed = 5f;
    Rigidbody2D myrigidbody;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
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
        Vector2 secondPlayerVelocity = new Vector2(myrigidbody.velocity.x, moveInput.y * secondPlayerMoveSpeed);
        myrigidbody.velocity = secondPlayerVelocity;
    }
}

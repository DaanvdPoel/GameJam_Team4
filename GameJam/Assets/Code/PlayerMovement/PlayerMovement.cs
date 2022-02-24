using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    ContactPoint2D point;
    float jump = 60;
    float fallSpeed = -90;
    float xMove = 0;
    private float xJump;
    float speed = 13f;
    Vector2 movementVector;
    bool isGrounded = false;
    private bool jumping;
    float jumpHeight;
    private bool holdingJump;
    Vector2 counterJumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpHeight = CalculateJumpForce(Physics2D.gravity.magnitude, jump);
        InputManager.Instance.inputActions.Player.Jump.performed += Jump;
        InputManager.Instance.inputActions.Player.Jump.canceled += JumpCancel;
        counterJumpForce = new Vector2(0, fallSpeed);
    }

    private void FixedUpdate()
    {
        movementVector = InputManager.Instance.inputActions.Player.Move.ReadValue<Vector2>();

        Move();

        if (jumping)
        {
            StopJump();
        }
    }

    private void StopJump()
    {
        if(!holdingJump && Vector2.Dot(rb.velocity, Vector2.up) > 0)
        {
            rb.AddForce(counterJumpForce);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        holdingJump = true;
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void JumpCancel(InputAction.CallbackContext context)
    {
        holdingJump = false;
    }

    private void Move()
    {
        if (InputManager.Instance.inputActions.Player.Move.inProgress)
        {
            xMove = movementVector.x;
            xJump = xMove;
            speed = 10f;
            var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
            transform.position += (Vector3)mover;
        }
        else if (movementVector == Vector2.zero)
        {
            if (jumping)
            {
                var mover = new Vector2(xJump, 0) * Time.fixedDeltaTime * speed;
                transform.position += (Vector3)mover;
            }
            else
            {
                speed = Mathf.MoveTowards(speed, 0, 1f);
                var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
                transform.position += (Vector3)mover;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        point = collision.GetContact(0);
        if(point.point.y < transform.position.y)
        {
            isGrounded = true;
            jumping = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        point = collision.GetContact(0);
        if (point.point.y < transform.position.y)
        {
            isGrounded = true;
            jumping = false;
        }
        else if(point.point.x <= transform.position.x || point.point.x >= transform.position.x)
            jumping = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        jumping = true;
    }

    public float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }
}
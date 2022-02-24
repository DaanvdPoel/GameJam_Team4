using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public bool movingLeft = false;
    public bool moving = false;
    public float fallSpeed = -90;
    public float jump = 60;
    public float maxSpeed;
    public bool jumping = false;
    public enum fallingState { falling, notFalling, standing};
    public fallingState state;

    float speed;
    float xJump;
    RaycastHit2D hit;
    Rigidbody2D rb;
    float xMove = 0;
    float jumpHeight;
    bool holdingJump;
    Vector2 oldPosition;
    ContactPoint2D point;
    Vector2 movementVector;
    bool isGrounded = false;
    Vector2 counterJumpForce;
    Vector2 newPos;
    Vector2 previousPos;
    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        state = fallingState.standing;
        jumpHeight = CalculateJumpForce(Physics2D.gravity.magnitude, jump);
        InputManager.Instance.inputActions.Player.Jump.performed += Jump;
        InputManager.Instance.inputActions.Player.Jump.canceled += JumpCancel;
        counterJumpForce = new Vector2(0, fallSpeed);
    }

    private void Update()
    {
        GroundCheck();

    }

    private void FixedUpdate()
    {
        movementVector = InputManager.Instance.inputActions.Player.Move.ReadValue<Vector2>();

        Move();
        if (jumping)
        {
            StopJump();
        }

        Falling();
    }

    private void Falling()
    {
        newPos = transform.position;

        if (newPos.y == previousPos.y)
            state = fallingState.standing;
        else if (newPos.y < previousPos.y)
            state = fallingState.falling;
        else if (newPos.y > previousPos.y)
            state = fallingState.notFalling;

        previousPos = transform.position;
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
            moving = true;
            speed = maxSpeed;
            oldPosition = transform.position;
            var mover = new Vector2(xMove, 0) * Time.fixedDeltaTime * speed;
            transform.position += (Vector3)mover;
            if(transform.position.x < oldPosition.x)
                movingLeft = true;
            else if(transform.position.x > oldPosition.x)
                movingLeft = false;
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
                moving = false;
            }
        }
    }

    private void GroundCheck()
    {
        hit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 0.1f);

        if (hit.point != Vector2.zero)
        {
            jumping = false;
            isGrounded = true;
        }
        else
        {
            jumping = true;
            isGrounded = false;
        }
    }

    public float CalculateJumpForce(float gravityStrength, float jumpHeight)
    {
        return Mathf.Sqrt(2 * gravityStrength * jumpHeight);
    }

    private void OnDestroy()
    {
        InputManager.Instance.inputActions.Player.Jump.performed -= Jump;
        InputManager.Instance.inputActions.Player.Jump.canceled -= JumpCancel;
    }
}
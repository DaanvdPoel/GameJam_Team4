using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    Vector2 movementVector;
    ContactPoint2D point;
    private bool _jumping;
    private bool _moving;
    private bool _flipped;


    private void FixedUpdate()
    {
        movementVector = InputManager.Instance.inputActions.Player.Move.ReadValue<Vector2>();

        if (movementVector.x != 0)
        {
            _moving = true;
        }
        else
        {
            _moving = false;
        }


        _anim.SetBool("Moving", _moving);
        _anim.SetBool("Jumping", _jumping);

        // Based off https://www.youtube.com/watch?v=pKZ7FIL2csU&ab_channel=ShootingDux

        if (movementVector.x < 0)
        {
            _flipped = true;
        }
        else if (movementVector.x > 0)
        {
            _flipped = false;
        }

        this.transform.rotation = Quaternion.Euler(new Vector3(0f, _flipped ? 180f : 0f, 0f));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        point = collision.GetContact(0);
        if (point.point.y < transform.position.y)
        {
            _jumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _jumping = true;
    }
}

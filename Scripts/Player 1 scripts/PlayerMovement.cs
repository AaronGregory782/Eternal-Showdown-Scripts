using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Animator anim;

    // Declares a variety of variables which are used in the movement script

    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // creates serialized fields which are used to adjust values without needing to modify the code

    void Update()
    {

        if (Gamepad.all[0].leftStick.right.isPressed){
            horizontal = 1;
        }
        else if (Gamepad.all[0].leftStick.left.isPressed){
            horizontal = -1;
        }
        else{
            horizontal = 0;
        }

        if (Gamepad.all[0].buttonSouth.isPressed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        // used to ad   d vertical or horizontal velocity to a character if a movement key is pressed.

        Flip();

        if (rb.linearVelocityX > 0.1f || rb.linearVelocityX < -0.1f)
        {
            anim.SetBool("IsRunning", true);
        }   
        else {
            anim.SetBool("IsRunning", false);
        }

        // plays the animation based on if the character is moving or not

    
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    // calculate the new velocity when a movement input is pressed

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // used to check if a character is on the ground which will allow them to jump or not

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        // changes the way a character is facing based on the left and right inputs
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement2 : MonoBehaviour
{
    private float horizontal2;
    private float speed2 = 8f;
    private float jumpingPower2 = 16f;
    private bool isFacingRight2 = true;

    public Animator anim;

    // Declares a variety of variables which are used in the movement script

    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // creates serialized fields which are used to adjust values without needing to modify the code

    void Update()
    {

        if (Gamepad.all[1].leftStick.right.isPressed){
            horizontal2 = 1;
        }
        else if (Gamepad.all[1].leftStick.left.isPressed){
            horizontal2 = -1;
        }
        else{
            horizontal2 = 0;
        }

        if (Gamepad.all[1].buttonSouth.isPressed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower2);
        }

        // used to ad   d vertical or horizontal velocity to a character if a movement key is pressed.

        Flip();

        if (rb.linearVelocityX > 0.1f || rb.linearVelocityX < -0.1f)
        {
            anim.SetBool("IsRunning2", true);
        }   
        else {
            anim.SetBool("IsRunning2", false);
        }

        // plays the animation based on if the character is moving or not

    
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal2 * speed2, rb.linearVelocity.y);
    }

    // calculate the new velocity when a movement input is pressed

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // used to check if a character is on the ground which will allow them to jump or not

    private void Flip()
    {
        if (isFacingRight2 && horizontal2 < 0f || !isFacingRight2 && horizontal2 > 0f)
        {
            isFacingRight2 = !isFacingRight2;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        // changes the way a character is facing based on the left and right inputs
    }
}

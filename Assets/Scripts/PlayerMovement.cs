using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public_Variables
    [Header("Movement")]
    public float accelerationSpeed;
    public float descelerationSpeed;
    public float maxSpeed;

    [Header("Jump")]
    public float jumpForce;

    [Header("Raycast - Ground")]
    public LayerMask groundMask;
    public float rayLength;
    #endregion

    #region Private_Variables
    private Vector2 horizontalMovement;
    private Vector3 slowDown;
    private bool isGrounded;
    private bool jumpPressed;
    private Ray ray;
    private RaycastHit hit;
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        JumpPressed();
    }

    void FixedUpdate()
    {
        IsGrounded();
        Movement();
        Jump();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);

        // Limit the velocity
        if (horizontalMovement.magnitude > maxSpeed)
        {
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxSpeed;
        }

        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, horizontalMovement.y);

        rb.velocity = Vector3.SmoothDamp(
            rb.velocity,
            new Vector3(0, rb.velocity.y, 0),
            ref slowDown,
            descelerationSpeed
            );

        if (isGrounded) 
        {
            rb.AddRelativeForce(
                    horizontal * accelerationSpeed * Time.deltaTime,
                    0,
                    vertical * accelerationSpeed * Time.deltaTime
                );
        }
        else
        {
            rb.AddRelativeForce(
            horizontal * accelerationSpeed / 2 * Time.deltaTime,
            0,
            vertical * accelerationSpeed / 2 * Time.deltaTime
            );
        }
    }

    void JumpPressed()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;
        }


    }

    void Jump()
    {
        if(jumpPressed)
        {
            jumpPressed = false;
            rb.AddRelativeForce(Vector3.up * jumpForce);
        }
    }

    void IsGrounded()
    {
        // Ray configuration
        ray.origin = transform.position;
        ray.direction = -transform.up;
        

        if(Physics.Raycast(ray, out hit, rayLength, groundMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
    }

}

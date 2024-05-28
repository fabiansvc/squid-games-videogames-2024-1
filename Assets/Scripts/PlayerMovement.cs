using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    #region Public_Variables
    [Header("Movement")]
    public float acelerationSpeed;
    public float desacelerationSpeed;
    public float maxSpeed;

    [Header("Jump")]
    public float jumpForce;

    [Header("Raycast — Ground")] 
    public LayerMask groundMask;
    public float rayLength;

    [Header("Animator")]
    public Animator animator;

    [Header("Audio")]
    public AudioSource walkAudioSource;
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

    void Movement()
    {   
        // Store the velocity
        horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        
        if(horizontalMovement.magnitude > maxSpeed)
        {
            // Limit the velocity to the max speed
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxSpeed;
        }

        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, horizontalMovement.y);

        if(isGrounded)
        {
            rb.velocity = Vector3.SmoothDamp(
                   rb.velocity, 
                   new Vector3(0, rb.velocity.y, 0), 
                   ref slowDown, 
                   desacelerationSpeed);

            rb.AddRelativeForce(
                    horizontal * acelerationSpeed * Time.deltaTime, // Move in the X axis
                    0, // Don't move in the Y axis
                    vertical * acelerationSpeed * Time.deltaTime); // Move in the Z axis

            if (horizontal != 0 || vertical != 0)
            {
                animator.Play("Running");

                if (!walkAudioSource.isPlaying)
                {
                    walkAudioSource.Play();
                }

                if (walkAudioSource.mute)
                {
                    walkAudioSource.mute = false;
                }

            }
            else
            {
                animator.Play("Idle");

                if (!walkAudioSource.mute)
                {
                    walkAudioSource.mute = true;
                }
            }
        }
        else
        {
            rb.AddRelativeForce(
                   horizontal * acelerationSpeed / 2 * Time.deltaTime, // Move in the X axis
                   0, // Don't move in the Y axis
                   vertical * acelerationSpeed / 2 * Time.deltaTime); // Move in the Z axis
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

    void InputPlayer()
    {
        // AD, if player press A or D, the value will be -1 or 1, if not the value will be 0
        horizontal = Input.GetAxis("Horizontal");
        // WS, if player press W or S, the value will be -1 or 1, if not the value will be 0
        vertical = Input.GetAxis("Vertical");
    }   

    void IsGrounded()
    {
        // Ray configuration
        ray.origin = transform.position;
        ray.direction = -transform.up;

        // Raycast configuration with the selective layer
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

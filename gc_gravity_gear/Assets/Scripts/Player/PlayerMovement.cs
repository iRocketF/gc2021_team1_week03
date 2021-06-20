using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // TODO here 
    // experiment with gravity to find low/zero g movement while jumping
    // experiment with double jumping
    // implement limited air control, dashing to move in the air but lower the amount 
    // of air control for a feeling of weight while in the air

    private GameManager manager;
    public CharacterController pController;
    public Camera pCam;

    // basic movement modifiers
    public float speed;
    public float gravity;
    public float jumpHeight;

    // dash modifiers
    public float dashCooldown; // how long until the player can dash again
    private float dashTimer; // counts time from last dash
    public float dashSpeed; // how fast the dash moves
    public float maxDashLength; // absolute max length of the dash
    private float dashRatio; // used for lerp
    private Vector3 ogPosition; // where the dash starts
    private Vector3 dashDirection; // direction of the dash
    private Vector3 dashPosition; // where the dash finishes
    public bool isDashing;
    public bool hasDashed;
    
    
    [SerializeField] private Vector3 velocity;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        pController = GetComponent<CharacterController>();
        pCam = GetComponentInChildren<Camera>();

        isDashing = false;
    }

    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Dash") && !hasDashed)
            Dash();

        else if (isDashing)
            DashLerp();

        else if (hasDashed)
            DashCooldown();
    }

    void Movement()
    {
        // force gravity on player, maybe disable for low/zero gravity
        if (pController.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // jump formula using square root
        if (Input.GetButtonDown("Jump") && CollisionFlags.Below != 0 && pController.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        //force player down if head hits ceiling mid jump
        if (!pController.isGrounded && (pController.collisionFlags & CollisionFlags.Above) != 0)
            velocity.y = -2f;

        // gravity speeds up while falling down, maybe not needed when in a space ship?
        velocity.y += gravity * Time.deltaTime;

        if (pController.isGrounded)
            pController.Move(((move * speed) * Time.deltaTime) + velocity * Time.deltaTime);
        else
            pController.Move(((move * speed) * Time.deltaTime) + velocity * Time.deltaTime);



    }

    void Dash()
    {
        ogPosition = transform.position;
        dashDirection = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        dashDirection.y = 0f;
        dashDirection.Normalize();

        float dashLength = maxDashLength;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, dashDirection, out hit, dashLength))
            dashLength = hit.distance;
        else
            dashLength = maxDashLength;

        dashPosition = transform.position + (dashDirection * dashLength);

        if (dashPosition != ogPosition)
            isDashing = true;

        //transform.position = transform.position + (dashDirection * dashLength);

    }

    void DashLerp()
    {
        dashRatio = dashRatio + (Time.deltaTime * dashSpeed);

        transform.position = Vector3.Lerp(ogPosition, dashPosition, dashRatio);

        if (dashRatio >= 1f)
        {
            isDashing = false;
            hasDashed = true;
            dashRatio = 0f;
        }

    }

    void DashCooldown()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer >= dashCooldown)
        {
            hasDashed = false;
            dashTimer = 0f;
        }
    }

    void Stomp()
    {

            

    }

}

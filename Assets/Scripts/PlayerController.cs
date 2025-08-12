using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpforce = 20f;

    //Create ground, avoid "Jump" much more
    [SerializeField] private LayerMask groundLayer;

    //Check player is standing on ground, is not it?
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private GameManager gameManager;
    private Animator animator;

    private bool DoubleJump;

    private Rigidbody2D rb;

    private AudioManager audioManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver() || gameManager.IsGameWin())
            return;
        CheckFall();
        HandleMovement();
        HandleJump();
        UppdateAnimation();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //Rotation player
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            audioManager.PlayJumpSound();
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
                DoubleJump = true;
            }
            else if (DoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
                DoubleJump = false;
            }
        }

        // Draw 1 circle point to check, if when groundCheck.position touch groundLayer return true
        //0.2f is distance from player to ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    private void CheckFall()
    {
        float normalizedZ = transform.eulerAngles.z > 180f
                            ? transform.eulerAngles.z - 360f
                            : transform.eulerAngles.z;
        if (normalizedZ == -90f || normalizedZ == 90f || normalizedZ == 180f)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void UppdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsJumping", isJumping);
    }


}

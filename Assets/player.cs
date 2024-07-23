using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private float xInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private bool isMoving;
    [SerializeField] private int facingDir = 1;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
        jumpForce = 8;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        AnimatorControllers();
        FilpController();
    }

    private void Move()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorControllers()
    {
        isMoving = (rb.velocity.x != 0);
        anim.SetBool("isMoving", isMoving);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FilpController()
    {
        if ((rb.velocity.x > 0 && !facingRight) || (rb.velocity.x < 0 && facingRight))
            Flip();
    }
}

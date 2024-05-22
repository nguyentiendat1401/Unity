using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h = 0f;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool isFacingRight = true;
    [SerializeField]
    private Animator anim;

    // Jump
    private BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask groundLayer;
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce;
    private int countJump = 2;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        Movement();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        anim.SetBool("IsJumping", !IsGrounded());
        

        if (IsGrounded() && countJump == 0)
        {
            countJump = 2;
        }
    }

    void Movement()
    {
        transform.position += new Vector3(h, 0f, 0f) * moveSpeed * Time.deltaTime;

        if (h > 0 && !isFacingRight)
        {
            // Flip
            Flip();
        }
        else if (h < 0 && isFacingRight)
        {
            // Flip
            Flip();
        }

        anim.SetFloat("Speed", Mathf.Abs(h));
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 scalePlayer = transform.localScale;
        scalePlayer.x *= -1f;
        transform.localScale = scalePlayer;
    }

    void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            countJump--;
            Debug.Log(countJump);
        }
        else
        {
            Debug.Log(countJump);
            if (countJump > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                countJump--;      
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
            boxCollider.bounds.size,0,Vector2.down,0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}

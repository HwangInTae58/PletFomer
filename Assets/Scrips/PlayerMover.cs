using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    Rigidbody2D rigidbody;
    Animator anim;
    SpriteRenderer sprite;

    float hSpeed;
    float vSpeed;
    bool _isJump;

    bool isJump
    {
        set
        {
            _isJump = value;
            anim.SetBool("IsJump", value);
        }
        get
        {
            return anim.GetBool("IsJump");
        }
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        hSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        anim.SetFloat("hSpeed",Mathf.Abs(hSpeed));
        transform.Translate(Vector2.right * hSpeed * Time.fixedDeltaTime);
        if (hSpeed < 0)
            sprite.flipX = true;
        else if(hSpeed > 0)
            sprite.flipX = false;
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
           // anim.SetBool("IsJump", isJump);
        }
        vSpeed = rigidbody.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            isJump = false;
            //anim.SetBool("IsJump", isJump);
        }
    }
}

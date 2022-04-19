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
    CapsuleCollider2D collider;

    float hSpeed;
    float vSpeed;
    bool _isJump;

    bool isGround
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
        collider = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        Move();
        Jump();
    }
    private void FixedUpdate()
    {
        Vector2 startvec = new Vector2(collider.transform.position.x, collider.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(startvec,Vector2.down,1.5f, LayerMask.GetMask("Ground"));
        if(null != hit.collider) 
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
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
        if (Input.GetButtonDown("Jump") && isGround == true)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
           // anim.SetBool("IsJump", isJump);
        }
        vSpeed = rigidbody.velocity.y;
        anim.SetFloat("vSpeed", vSpeed);
    }
    private void ItemGet(Item item)
    {
        item.Drops();
    }
    private void Attack(Forge forge)
    {
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        forge.Died();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            if(transform.position.y > other.transform.position.y)
            {
                Forge froge = other.gameObject.GetComponent<Forge>();
                Attack(froge);
            }
        }
       
        if (other.gameObject.tag == "Item")
        {
            
            Debug.Log("Drops");
            Item item = other.gameObject.GetComponent<Item>();
            ItemGet(item);
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour , IMonster
{
    Rigidbody2D rigid;
    Animator anime;
    CapsuleCollider2D collider;
    SpriteRenderer sprite;

    public float moveSpeed = 7f;
    float direction = -1f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        rigid.AddForce(new Vector2(direction , 0) * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        
    }
    private void FixedUpdate()
    {
        Vector2 startvec = new Vector2(collider.transform.position.x, collider.transform.position.y);
        RaycastHit2D rayLeft = Physics2D.Raycast(startvec, Vector2.left, 5f, LayerMask.GetMask("Ground"));
        RaycastHit2D rayRight = Physics2D.Raycast(startvec, Vector2.right, 5f, LayerMask.GetMask("Ground"));
        if (null != rayLeft.collider)
        {
            sprite.flipX = true;
            direction = 1;
        }
        else if(null != rayRight.collider)
        {
            sprite.flipX = false;
            direction = -1;
        }
        
    }
    public void Died()
    {
        anime.SetTrigger("Die");
        Debug.Log("쥐사망");
    }
    public void OnEndDieEffect()
    {
        Destroy(gameObject);
    }
}

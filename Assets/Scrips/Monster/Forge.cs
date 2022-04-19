using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour
{
    enum State
    {
        IDLE,
        MOVE,
        JUMP,
        ATTACK,
        SIZE,
    }
    State curState;
    Animator anime;
    Rigidbody2D rigid;

    public float jumpForce = 7.5f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    public void Idle()
    {
        StartCoroutine(IdlePattern());
    }
    public void Jump()
    {
        StartCoroutine(JumpPattern());
    }
    IEnumerator IdlePattern()
    {
        yield return new WaitForSeconds(3.0f);
        anime.SetBool("IsJump", true);
        yield return null;
    }
    IEnumerator JumpPattern()
    {
        rigid.AddForce(new Vector2(-1, 1) * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        yield return null;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 9) { 
        anime.SetBool("IsJump", false);
        }
    }
    public void Died()
    {
        anime.SetTrigger("Die");
    }
    public void OnEndDieEffect()
    {
        Destroy(gameObject);
    }
}

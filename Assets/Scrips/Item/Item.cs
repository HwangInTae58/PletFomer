using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator anim;
    CircleCollider2D collider;
    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }
    public void Drops()
    {
        anim.SetTrigger("IsDrop");
    }
    public void GetItem()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        if(gameObject.layer == 10)
        {
            anim.SetBool("Gem", true);
        }
        else if(gameObject.layer == 11)
        {
            anim.SetBool("Gem", false);
        }
    }

}

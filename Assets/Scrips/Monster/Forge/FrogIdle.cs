using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogIdle : StateMachineBehaviour
{
    Forge forge;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        forge = animator.gameObject.GetComponent<Forge>();
        forge.Idle();
    }
}

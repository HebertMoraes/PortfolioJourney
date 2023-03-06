using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSM : StateMachineBehaviour
{
    public float alturaMaxPulo;
    public float velocidadePulo;
    public float velocidadePouso;
    private bool pousando;
    private CharacterController charControll;
    private Vector3 newMove;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pousando = false;
        charControll = animator.gameObject.GetComponent<CharacterController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pousando)
        {
            newMove.Set(0, velocidadePouso * Time.deltaTime, 0);
        }
        else
        {
            if (animator.transform.position.y < alturaMaxPulo)
            {
                newMove.Set(0, velocidadePulo * Time.deltaTime, 0);
            }
            else
            {
                pousando = true;
                newMove.Set(0, velocidadePouso * Time.deltaTime, 0);
            }
        }
        charControll.Move(newMove);

        if (charControll.isGrounded && pousando)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                animator.SetInteger("animState", 1);
            }
            else
            {
                animator.SetInteger("animState", 0);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {

    // }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

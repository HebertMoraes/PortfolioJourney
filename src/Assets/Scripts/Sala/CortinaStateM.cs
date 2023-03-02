using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortinaStateM : StateMachineBehaviour
{
    private AudioSource audioVideo;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioVideo = GameObject.Find("VideoTela").GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float currentFrame = 0;

        try
        {
            currentFrame = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length *
            (animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1) *
            animator.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate;
        }
        catch
        {
            currentFrame = 0;
        }
        if (currentFrame >= 116)
        {
            animator.speed = 0;
            animator.SetBool("aberto", true);
            if (!audioVideo.isPlaying)
            {
                audioVideo.Play();
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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

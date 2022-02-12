using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStateMachine : StateMachineBehaviour
{
    public float velocidadeJump;
    public float maxAlcancePulo;
    [HideInInspector]
    public bool pousando;
    private Transform jogadorObj;

    public float AjusteAnimInicioPulo1;
    public float AjusteAnimSpeed1;
    public float AjusteAnimInicioPulo2;
    public float AjusteAnimSpeed2;
    public float AjusteAnimInicioPulo3;
    public float AjusteAnimSpeed3;

    private float posYinicial;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jogadorObj = animator.gameObject.transform;
        posYinicial = jogadorObj.position.y;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float valAjusteAnimAtual;
        //ajuste de velocidade da animação e velocidade do pulo no inicio
        if (stateInfo.normalizedTime < 0.2) {
            animator.speed = (float)AjusteAnimSpeed1;
            valAjusteAnimAtual = (float)AjusteAnimInicioPulo1;
        } 
        else if (stateInfo.normalizedTime >= 0.2 && stateInfo.normalizedTime < 0.3) {
            animator.speed = (float)AjusteAnimSpeed2;
            valAjusteAnimAtual = (float)AjusteAnimInicioPulo2;
        }
        else {
            animator.speed = (float)AjusteAnimSpeed3;
            valAjusteAnimAtual = (float)AjusteAnimInicioPulo3;
        }

        if (jogadorObj.position.y < posYinicial + maxAlcancePulo && !pousando) {

            //movimentando de fato
            jogadorObj.GetComponent<CharacterController>().Move(new Vector3(0, (velocidadeJump * valAjusteAnimAtual) 
                * Time.deltaTime, 0));

        } else {
            pousando = true;
        }

        if (pousando && jogadorObj.GetComponent<CharacterController>().isGrounded) {
            animator.SetInteger("animacaoTransicao", 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pousando = false;
    }

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

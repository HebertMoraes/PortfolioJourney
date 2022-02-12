using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBasicaSala : MonoBehaviour
{   
    public float velocidadeMov;
    private float velRotacaoAtual;
    //public float velRotacaoMaxFrenteTras;
    public float velRotacaoPadrao;
    CharacterController charControll;
    
    //não entendi porque statico
    public static float xMove, zMove;
    private float gravity;
    public float multiplicarGravityCaindo;

    private Animator animator;
 
    void Awake()
    {
        charControll = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        MovController();
        //AlterarVelRotacao();
        RotacaoController();
    }

    // Update is called once per frame
    void MovController()
    {
        zMove = Input.GetAxis("Vertical");
        xMove = Input.GetAxis("Horizontal");
        
        //gravidade
        if (animator.GetInteger("animacaoTransicao") == 2 && !animator.GetBehaviour<JumpStateMachine>().pousando) 
        {
            gravity = 0;
        } 
        else if (animator.GetInteger("animacaoTransicao") == 2 && animator.GetBehaviour<JumpStateMachine>().pousando) 
        { 
            gravity = Physics.gravity.y * Time.deltaTime * multiplicarGravityCaindo; 
        }
        else 
        { 
            gravity = Physics.gravity.y * Time.deltaTime; 
        }
        
        Vector3 moveAxis = new Vector3(xMove, gravity, zMove);
        charControll.Move(((moveAxis) * velocidadeMov * Time.deltaTime));
    }
    void RotacaoController ()
    {
        if (xMove > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 
            velRotacaoPadrao * Time.deltaTime); 
        }
        else if (xMove < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 
            velRotacaoPadrao * Time.deltaTime); 
        }
        if (zMove > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 
            velRotacaoPadrao * Time.deltaTime);
        }
        else if (zMove < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 
            velRotacaoPadrao * Time.deltaTime); 
        }
    }

    /*
    void AlterarVelRotacao () 
    {
        //rotacao
        if (transform.position.z >= zMaxPosicao) {
            velRotacaoAtual = velRotacaoMaxFrenteTras;
        } else if (transform.position.z <= zMinPosicao) {
            velRotacaoAtual = velRotacaoMaxFrenteTras;
        } else {
            velRotacaoAtual = velRotacaoPadrao;
        }
    }
    */
}

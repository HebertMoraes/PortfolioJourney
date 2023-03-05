using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovBasicaCorredor : MonoBehaviour
{
    [HideInInspector]
    public bool andandoMaxParaFrente;
    [HideInInspector]
    public bool andandoMaxParaTras;
    public float zMaxPosicao;
    public float zMinPosicao;
    
    // public GameObject corredorPrefab;

    public float velocidadeMov;
    private float velRotacaoAtual;
    public float velRotacaoMaxFrenteTras;
    public float velRotacaoPadrao;
    CharacterController charControll;
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
        VerificarMaximosZ();
        MovController();
        AlterarVelRotacao();
        RotacaoController();
    }

    // Update is called once per frame
    void MovController()
    {
        zMove = Input.GetAxis("Vertical");
        if (zMove > 0 && andandoMaxParaFrente) {
            zMove = 0;
        }
        if (zMove < 0 && andandoMaxParaTras) {
            zMove = 0;
        }

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
            velRotacaoAtual * Time.deltaTime); 
        }
        else if (xMove < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 
            velRotacaoAtual * Time.deltaTime); 
        }
        if (zMove > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 
            velRotacaoAtual * Time.deltaTime);
        }
        else if (zMove < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 
            velRotacaoAtual * Time.deltaTime); 
        }
    }

    void VerificarMaximosZ () 
    {
        //Maximos Z
        if (transform.position.z >= zMaxPosicao && Input.GetAxis("Vertical") > 0) {
            andandoMaxParaFrente = true;
        } else { andandoMaxParaFrente = false; }

        if (transform.position.z <= zMinPosicao  && Input.GetAxis("Vertical") < 0) {
            andandoMaxParaTras = true;
        } else { andandoMaxParaTras = false; }
    }

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
}

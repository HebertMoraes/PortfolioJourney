using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    [HideInInspector]
    public bool andandoMaxParaFrente;
    [HideInInspector]
    public bool andandoMaxParaTras;
    public float zMaxPosicao;
    public float zMinPosicao;
    public float velocidadeMov;
    public float alturaMaxPulo;
    public GameObject corredorPrefab;
    private Vector3 newMove;
    private Animator animator;
    private CharacterController charControll;
    private bool pousando;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        charControll = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        VerificarMaximosZ();

        newMove.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (newMove != Vector3.zero) {
            transform.forward = Vector3.Slerp(transform.forward, newMove, Time.deltaTime * 10);
        }
        newMove.y = Physics.gravity.y * Time.deltaTime;

        if (newMove.z > 0 && andandoMaxParaFrente) {
            newMove.z = 0;
        } 
        if (newMove.z < 0 && andandoMaxParaTras) {
            newMove.z = 0;
        }

        if (charControll.isGrounded && Input.GetKey(KeyCode.Space))
        {
            animator.SetInteger("animState", 2);
        }

        if (charControll.isGrounded && animator.GetInteger("animState") != 2) {

            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
                animator.SetInteger("animState", 1); 
            } else {
                animator.SetInteger("animState", 0); 
            }
        }

        charControll.Move((newMove * velocidadeMov) * Time.deltaTime);
    }

    void VerificarMaximosZ()
    {
        if (transform.position.z >= zMaxPosicao && Input.GetAxis("Vertical") > 0)
        {
            andandoMaxParaFrente = true;
        }
        else { andandoMaxParaFrente = false; }

        if (transform.position.z <= zMinPosicao && Input.GetAxis("Vertical") < 0)
        {
            andandoMaxParaTras = true;
        }
        else { andandoMaxParaTras = false; }
    }
}

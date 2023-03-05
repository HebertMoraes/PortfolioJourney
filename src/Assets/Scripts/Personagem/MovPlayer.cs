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
    public GameObject corredorPrefab;
    private Vector3 newMove;
    private Animator animator;
    private CharacterController charControll;

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

        if (newMove.z > 0 && andandoMaxParaFrente) {
            newMove.z = 0;
        } 
        if (newMove.z < 0 && andandoMaxParaTras) {
            newMove.z = 0;
        }

        // if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        // {
        //     animator.SetBool("andando", true);
        // } else {
        //     animator.SetBool("andando", false);
        // }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            animator.SetInteger("animState", 2);
        }

        if (charControll.isGrounded && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)) {
           animator.SetInteger("animState", 1); 
        } else if (charControll.isGrounded && (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)) {
            animator.SetInteger("animState", 0); 
        }

        charControll.Move(newMove * velocidadeMov * Time.deltaTime);
        charControll.Move(Vector3.down * Time.deltaTime);
    }

    void VerificarMaximosZ()
    {
        //Maximos Z
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCameraSala : MonoBehaviour
{
    public int indiceParedeEsquerda;
    public int indiceParedeDireita;
    private GameObject sala;
    private float velocidadeMovPlayer;
    private float posXLimiteMin;
    private float posXLimiteMax;
    private float xMove;
    // Start is called before the first frame update
    void Start()
    {
        velocidadeMovPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovBasicaSala>().velocidadeMov;

        sala = GameObject.FindGameObjectWithTag("Sala");
        posXLimiteMin = sala.transform.GetChild(indiceParedeEsquerda).position.x;
        posXLimiteMax = sala.transform.GetChild(indiceParedeDireita).position.x;
    }

    // Update is called once per frame
    void Update()
    {   
        xMove = Input.GetAxis("Horizontal");

        if (transform.position.x < posXLimiteMin) {
            transform.position = new Vector3(
                posXLimiteMin, 
                transform.position.y, 
                transform.position.z);
        }
        if (transform.position.x > posXLimiteMax) {
            transform.position = new Vector3(
                posXLimiteMax, 
                transform.position.y, 
                transform.position.z);
        }

        if (transform.position.x >= posXLimiteMin && transform.position.x <= posXLimiteMax) {
            transform.position = new Vector3(
                transform.position.x + (xMove * velocidadeMovPlayer * Time.deltaTime), 
                transform.position.y, 
                transform.position.z);
        }
    }
}

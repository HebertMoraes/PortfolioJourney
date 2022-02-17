using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterarOpacidade : MonoBehaviour
{
    private float valorAlterar;
    private bool alterar;
    private Material textura;
    private float alphaAtual;
    public float limiteOpacidadeAtivarNarrativa;

    // Start is called before the first frame update
    void Start()
    {
        textura = GetComponent<MeshRenderer>().material;
        alphaAtual = textura.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (textura.color.a < limiteOpacidadeAtivarNarrativa) {
            GetComponent<AcionarNarrativa>().habilitado = false;
            GetComponent<BoxCollider>().isTrigger = true;
        } else {
            GetComponent<AcionarNarrativa>().habilitado = true;
            GetComponent<BoxCollider>().isTrigger = false;
        }

        if ((alphaAtual + (valorAlterar * Time.deltaTime)) < 0 || (alphaAtual + (valorAlterar * Time.deltaTime)) > 1) {
            alterar = false;
        }

        if (alterar) {
            alphaAtual += (valorAlterar * Time.deltaTime);

            Color novaCor = new Color(
                textura.color.r,
                textura.color.g,
                textura.color.b,
                alphaAtual
            );
            textura.color = novaCor;
        }
    }

    public void AlterarOpacidadeMethod(float valorAlterar1) {
        valorAlterar = valorAlterar1;
        alterar = true;
    }
}

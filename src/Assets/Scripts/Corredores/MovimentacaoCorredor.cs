using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoCorredor : MonoBehaviour
{
    public int limitePosZPersonagemAndarTras;
    public int limiteCorredorAtras;

    private GameObject personagem;

    // Start is called before the first frame update
    void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] arrayCorredores = GameObject.FindGameObjectsWithTag("Corredor");
        int corredoresMaisQueLimite = 0;

        foreach (GameObject corredor in arrayCorredores) {
            if (corredor.transform.position.z <= limitePosZPersonagemAndarTras) {
                corredoresMaisQueLimite += 1;
            }
        }

        if (personagem.GetComponent<MovBasicaCorredor>().andandoMaxParaFrente) {

            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z - personagem.GetComponent<MovBasicaCorredor>().
                    velocidadeMov * Time.deltaTime);
        }
        if (personagem.GetComponent<MovBasicaCorredor>().andandoMaxParaTras && corredoresMaisQueLimite 
            >= limiteCorredorAtras) {

            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y,
                gameObject.transform.position.z + personagem.GetComponent<MovBasicaCorredor>().
                    velocidadeMov * Time.deltaTime);
        }
    }
}

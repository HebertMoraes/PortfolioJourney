using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFlutuanteCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
            //TRATAMENTO DA NARRATIVA DOS OBJFLUTUANTES
        /*
        if (hit.gameObject.CompareTag("ObjFlutuante") && podeTocarNarrativa) {
            podeTocarNarrativa = false;
            contarEspera = true;
            Debug.Log("alouu");
            hit.gameObject.GetComponent<AcionarNarrativa>().iniciarNarrativa();
        }
        */
        if (hit.gameObject.CompareTag("ObjFlutuante")) {
            hit.gameObject.GetComponent<AcionarNarrativa>().iniciarNarrativa();
            hit.gameObject.GetComponent<AcionarLegendaHud>().AtivarLegenda();
        }
        //
    }
}

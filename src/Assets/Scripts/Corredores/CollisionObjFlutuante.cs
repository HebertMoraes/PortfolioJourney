using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObjFlutuante : MonoBehaviour
{
    public float valorDiminuirOpacidade;
    public float valorAumentarOpacidade;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ObjFlutuante")) {
            //other.GetComponent<MeshRenderer>().enabled = false;
        other.GetComponent<AlterarOpacidade>().AlterarOpacidadeMethod(valorDiminuirOpacidade);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("ObjFlutuante")) {
            //other.GetComponent<MeshRenderer>().enabled = true;
            other.GetComponent<AlterarOpacidade>().AlterarOpacidadeMethod(valorAumentarOpacidade);
        }
    }
}

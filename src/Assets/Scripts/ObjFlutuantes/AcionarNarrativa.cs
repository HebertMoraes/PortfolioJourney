using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionarNarrativa : MonoBehaviour
{
    public AudioClip narrativaClip;
    private GameObject audioController;
    public bool habilitado;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("AudioController");
        habilitado = true;
    }

    
    public void iniciarNarrativa(){
        if (habilitado) {
            audioController.GetComponent<NarrativaManipulation>().TocarNarrativa(narrativaClip);
        }
    }
    
    /*
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            audioController.GetComponent<NarrativaManipulation>().TocarNarrativa(narrativaClip);
        }
    }
    */
}

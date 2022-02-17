using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativaManipulation : MonoBehaviour
{
    public float tempoDeEsperaNarrativaObjFlutuante;
    private float tempoEsperaAtual;
    public AudioSource audioSourceNarrativa;

    private bool tocandoAlgumaNarrativa;
    private bool iniciarOutraNarrativa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSourceNarrativa.isPlaying && !iniciarOutraNarrativa) {
            tocandoAlgumaNarrativa = false;
        }
        if (iniciarOutraNarrativa) {
            tempoEsperaAtual += Time.deltaTime;
        }
        if (tempoEsperaAtual >= tempoDeEsperaNarrativaObjFlutuante) {
            audioSourceNarrativa.Play();

            iniciarOutraNarrativa = false;
            tempoEsperaAtual = 0;
            tocandoAlgumaNarrativa = true;
        }
    }

    public void TocarNarrativa (AudioClip audioClip) {
        
        if (!tocandoAlgumaNarrativa) {

            audioSourceNarrativa.clip = audioClip;
            audioSourceNarrativa.Play();
            tocandoAlgumaNarrativa = true;

        } else {
            audioSourceNarrativa.Stop();
            tempoEsperaAtual = 0;
            audioSourceNarrativa.clip = audioClip;
            iniciarOutraNarrativa = true;
            tocandoAlgumaNarrativa = true;
        }
    }
}

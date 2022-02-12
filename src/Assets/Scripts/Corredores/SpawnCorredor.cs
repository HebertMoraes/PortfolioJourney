using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnCorredor : MonoBehaviour
{
    public float distanciaDelete;
    public float distanciaSpawn;
    private GameObject personagem;
    private GameObject corredorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        personagem = GameObject.FindGameObjectWithTag("Player");
        //Talvez seja melhor e faça mais sentido esse prefab do corredor estar no GameController
        corredorPrefab = personagem.GetComponent<MovBasicaCorredor>().corredorPrefab;

        if (gameObject.GetComponent<SpawnDoors>().isActiveAndEnabled) {
            gameObject.GetComponent<SpawnDoors>().SpawnDoorMethod();
        }
        if (gameObject.GetComponent<SpawnObjFlutuantes>().isActiveAndEnabled) {
            gameObject.GetComponent<SpawnObjFlutuantes>().SpawnObjFlutuantesMethod();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.z <= -distanciaDelete
            && personagem.GetComponent<MovBasicaCorredor>().andandoMaxParaFrente) {
            
            Vector3 posicaoParaSpawn = new Vector3(corredorPrefab.transform.position.x, 
                corredorPrefab.transform.position.y, 
                distanciaSpawn);

            Instantiate(corredorPrefab, posicaoParaSpawn, corredorPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}

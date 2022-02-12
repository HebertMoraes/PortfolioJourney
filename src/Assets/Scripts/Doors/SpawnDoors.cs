using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour
{
    private GameObject spawnSystemObj;

    private void Start() {
        //esse método deve existir e vazio para que exista a caixa de Enable no editor,
        //ela é usada para uma verificação no SpawnCorredor.
    }

    public void SpawnDoorMethod()       
    {
        spawnSystemObj = GameObject.FindGameObjectWithTag("GameController");

        Transform tranformParedeAtual = gameObject.transform.GetChild(
            spawnSystemObj.GetComponent<DoorManipulation>().EscolherParede());
    
        Vector3 posicaoSpawn = new Vector3(tranformParedeAtual.position.x, 
            tranformParedeAtual.position.y, tranformParedeAtual.position.z + Random.Range(-1, 2));

        GameObject portaParaSpawnar = spawnSystemObj.GetComponent<DoorManipulation>().
            EscolherPortaSpawnar();

        Instantiate(portaParaSpawnar, posicaoSpawn, portaParaSpawnar.transform.rotation, 
            gameObject.transform);
    }
}

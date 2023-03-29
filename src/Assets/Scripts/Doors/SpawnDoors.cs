using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour
{
    public float posXSpawnDoorLeft;
    public float posXSpawnDoorRight;
    private GameObject spawnSystemObj;

    private void Start() {
        //esse método deve existir e vazio para que exista a caixa de Enable no editor,
        //ela é usada para uma verificação no SpawnCorredor.
    }

    public void SpawnDoorMethod()       
    {
        spawnSystemObj = GameObject.FindGameObjectWithTag("GameController");

        int doorIndexChosen = spawnSystemObj.GetComponent<DoorManipulation>().EscolherParede();
        
        Transform tranformParedeAtual = gameObject.transform.GetChild(
            doorIndexChosen);

        GetComponent<SpawnLampada>().SpawnLamp(doorIndexChosen, tranformParedeAtual.transform.position.z);
    
        Vector3 posicaoSpawn = new Vector3(
            doorIndexChosen == 0? posXSpawnDoorLeft : posXSpawnDoorRight, 
            tranformParedeAtual.position.y, 
            tranformParedeAtual.position.z + Random.Range(-1, 2)
        );

        GameObject portaParaSpawnar = spawnSystemObj.GetComponent<DoorManipulation>().
            EscolherPortaSpawnar();

        GameObject newDoor = Instantiate(portaParaSpawnar, posicaoSpawn, 
                portaParaSpawnar.transform.rotation, gameObject.transform);


        if(tranformParedeAtual.transform.GetSiblingIndex() == 0) {
            newDoor.transform.Rotate(new Vector3(0, -90, 0));
        } else if (tranformParedeAtual.transform.GetSiblingIndex() == 1) {
            newDoor.transform.Rotate(new Vector3(0, 90, 0));
        } else {
            newDoor.transform.Rotate(new Vector3(0, -90, 0));
        }
        newDoor.transform.Translate(new Vector3(0, 0, (float)-0.6));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjFlutuantes : MonoBehaviour
{
    private GameObject spawnSystemObj;

    private void Start() {
        //esse método deve existir e vazio para que exista a caixa de Enable no editor,
        //ela é usada para uma verificação no SpawnCorredor.
    }

    public void SpawnObjFlutuantesMethod()       
    {
        spawnSystemObj = GameObject.FindGameObjectWithTag("GameController");
    
        Vector3 posicaoSpawn = new Vector3(
            gameObject.transform.position.x + Random.Range((float)-2.5 - Random.value, 
            (float)2.5 + Random.value), 
            gameObject.transform.position.y + Random.Range((float)2.5 - Random.value, 
            (float)4.1 + Random.value), 
            gameObject.transform.position.z + Random.Range((float)-1.1 - Random.value, 
            (float)1.1 + Random.value));

        GameObject objFlutuanteParaSpawnar = spawnSystemObj.GetComponent<ObjFlutuanteManipulation>().
           EscolherObjSpawnar();

        Instantiate(objFlutuanteParaSpawnar, posicaoSpawn, 
            objFlutuanteParaSpawnar.transform.rotation, gameObject.transform);
    }
}

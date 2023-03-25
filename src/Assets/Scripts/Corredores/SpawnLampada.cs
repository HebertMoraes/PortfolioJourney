using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLampada : MonoBehaviour
{
    public GameObject lampadaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLamp(int indexWall) {

        Vector3 posicaoSpawn = new Vector3(lampadaPrefab.transform.position.x, 
            lampadaPrefab.transform.position.y, lampadaPrefab.transform.position.z + Random.Range(-1, 2));

        GameObject newLampada = Instantiate(lampadaPrefab, 
                posicaoSpawn, 
                lampadaPrefab.transform.rotation, 
                indexWall == 0? transform.GetChild(1) : transform.GetChild(0));

        if (indexWall == 0) {
            newLampada.transform.Rotate(new Vector3(0, -90, 0));
        } else {
            newLampada.transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLampada : MonoBehaviour
{
    public GameObject lampadaPrefab;
    public GameObject dummyLampadaPrefab;

    public float posXSpawnLeft;
    public float posXSpawnRight;
    public float posYToSpawn;
    public float chanceToSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnLamp(int indexWall, float posZToSpawn)
    {
        if (chanceToSpawn >= Random.value)
        {
            Vector3 posicaoSpawn = new Vector3(
                indexWall == 0 ? posXSpawnRight : posXSpawnLeft,
                posYToSpawn,
                posZToSpawn + Random.Range(-1, 2)
            );

            GameObject newLampada = Instantiate(
                lampadaPrefab,
                posicaoSpawn,
                lampadaPrefab.transform.rotation,
                transform
            );

            if (indexWall == 1)
            {
                newLampada.transform.Rotate(new Vector3(0, 180, 0));
            }
        } else {
            GameObject newLampada = Instantiate(
                dummyLampadaPrefab,
                new Vector3(0, 0, 0),
                lampadaPrefab.transform.rotation,
                transform
            );
        }
    }
}

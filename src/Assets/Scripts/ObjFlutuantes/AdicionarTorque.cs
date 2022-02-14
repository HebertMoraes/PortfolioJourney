using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionarTorque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddTorque(
            new Vector3(0, Random.Range(-Random.value, Random.value), 
            Random.Range(-Random.value, Random.value)), 
            ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCameraSala : MonoBehaviour
{
    public float posXLimiteMin;
    public float posXLimiteMax;
    private float velocidadeMovPlayer;

    // Start is called before the first frame update
    void Start()
    {
        velocidadeMovPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovPlayer>().velocidadeMov;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + (Input.GetAxis("Horizontal") * velocidadeMovPlayer * Time.deltaTime) >= 
            posXLimiteMin && Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(
                    transform.position.x + (Input.GetAxis("Horizontal") * velocidadeMovPlayer * Time.deltaTime),
                    transform.position.y,
                    transform.position.z);
        }

        if (transform.position.x + (Input.GetAxis("Horizontal") * velocidadeMovPlayer * Time.deltaTime) <= 
            posXLimiteMax && Input.GetAxis("Horizontal") > 0)
        {
            transform.position = new Vector3(
                    transform.position.x + (Input.GetAxis("Horizontal") * velocidadeMovPlayer * Time.deltaTime),
                    transform.position.y,
                    transform.position.z);
        }
    }
}

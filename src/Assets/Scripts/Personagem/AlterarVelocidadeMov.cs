using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterarVelocidadeMov : MonoBehaviour
{
    public float valorAlterarVelMov;
    public float maxVelocidadeMov;
    public float minVelocidadeMov;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MovPlayer>().velocidadeMov > maxVelocidadeMov) {
            GetComponent<MovPlayer>().velocidadeMov = maxVelocidadeMov;
        }
        if (GetComponent<MovPlayer>().velocidadeMov < minVelocidadeMov) {
            GetComponent<MovPlayer>().velocidadeMov = minVelocidadeMov;
        }

        if (Input.GetKey(KeyCode.Q)) {

            if (GetComponent<MovPlayer>().velocidadeMov <= maxVelocidadeMov
            && GetComponent<MovPlayer>().velocidadeMov >= minVelocidadeMov){
                GetComponent<MovPlayer>().velocidadeMov -= valorAlterarVelMov * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.W)) {

            if (GetComponent<MovPlayer>().velocidadeMov <= maxVelocidadeMov
            && GetComponent<MovPlayer>().velocidadeMov >= minVelocidadeMov){
                GetComponent<MovPlayer>().velocidadeMov += valorAlterarVelMov * Time.deltaTime;
            }
        }
    }
}

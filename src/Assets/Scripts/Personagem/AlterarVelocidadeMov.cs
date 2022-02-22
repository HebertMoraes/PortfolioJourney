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
        if (GetComponent<MovBasicaCorredor>().velocidadeMov > maxVelocidadeMov) {
            GetComponent<MovBasicaCorredor>().velocidadeMov = maxVelocidadeMov;
        }
        if (GetComponent<MovBasicaCorredor>().velocidadeMov < minVelocidadeMov) {
            GetComponent<MovBasicaCorredor>().velocidadeMov = minVelocidadeMov;
        }

        if (Input.GetKey(KeyCode.Q)) {

            if (GetComponent<MovBasicaCorredor>().velocidadeMov <= maxVelocidadeMov
            && GetComponent<MovBasicaCorredor>().velocidadeMov >= minVelocidadeMov){
                GetComponent<MovBasicaCorredor>().velocidadeMov -= valorAlterarVelMov * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.W)) {

            if (GetComponent<MovBasicaCorredor>().velocidadeMov <= maxVelocidadeMov
            && GetComponent<MovBasicaCorredor>().velocidadeMov >= minVelocidadeMov){
                GetComponent<MovBasicaCorredor>().velocidadeMov += valorAlterarVelMov * Time.deltaTime;
            }
        }
    }
}

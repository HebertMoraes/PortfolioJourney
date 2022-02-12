using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpurrarObjetos : MonoBehaviour
{
    public float forcaEmpurrar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {

        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null) {
            Vector3 direcaoDeEmpurrar = hit.gameObject.transform.position - transform.position;

            direcaoDeEmpurrar.Normalize();

            rigidbody.AddForceAtPosition(direcaoDeEmpurrar * forcaEmpurrar, transform.position, ForceMode.Impulse);
        }
    }
}

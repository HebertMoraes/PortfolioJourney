using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GoToGameDetails : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("teste se encostou");
            Hello();
        }
    }

    private void OnTriggerExit(Collider other) {
        
    }
}

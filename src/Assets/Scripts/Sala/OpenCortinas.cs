using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenCortinas : MonoBehaviour
{
    public Animator cortinasAnim;
    private GameObject PressToOpenObj;
    private bool PressToOpen;

    // Start is called before the first frame update
    void Start()
    {
        PressToOpenObj = GameObject.Find("OpenCortina");
    }

    // Update is called once per frame
    void Update()
    {
        if (PressToOpen) {
            if (Input.GetKeyDown(KeyCode.X)) {
                PressToOpen = false;
                PressToOpenObj.GetComponent<RawImage>().enabled = false;
                PressToOpenObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                cortinasAnim.SetBool("abrindo", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && !cortinasAnim.GetBool("abrindo") && !cortinasAnim.GetBool("aberto")) {
            PressToOpenObj.GetComponent<RawImage>().enabled = true;
            PressToOpenObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            PressToOpen = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        PressToOpenObj.GetComponent<RawImage>().enabled = false;
        PressToOpenObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        PressToOpen = false;
    }
}

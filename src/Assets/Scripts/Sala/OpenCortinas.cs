using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenCortinas : MonoBehaviour
{
    public Animator cortinasAnim;
    private GameObject fundoPressToEnter;
    private bool PressToEnter;

    // Start is called before the first frame update
    void Start()
    {
        fundoPressToEnter = GameObject.Find("FundoEnterDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if (PressToEnter) {
            if (Input.GetKeyDown(KeyCode.X)) {
                PressToEnter = false;
                fundoPressToEnter.GetComponent<RawImage>().enabled = false;
                fundoPressToEnter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
                cortinasAnim.SetBool("abrindo", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && !cortinasAnim.GetBool("abrindo") && !cortinasAnim.GetBool("aberto")) {
            fundoPressToEnter.GetComponent<RawImage>().enabled = true;
            fundoPressToEnter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            PressToEnter = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        fundoPressToEnter.GetComponent<RawImage>().enabled = false;
        fundoPressToEnter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        PressToEnter = false;
    }
}

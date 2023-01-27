using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public string sceneToEnter;
    private bool PressToEnter;
    private GameObject SpawnSystemObj;
    private GameObject fundoPressToEnter;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSystemObj = GameObject.FindGameObjectWithTag("GameController");
        fundoPressToEnter = GameObject.Find("FundoEnterDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if (PressToEnter) {
            if (Input.GetKeyDown(KeyCode.X)) {
                
                if (SceneManager.GetActiveScene().name == "Corredor"){
                    SpawnSystemObj.GetComponent<MudarScene>().mudarSalvarObjs(sceneToEnter);
                } else {
                    SceneManager.LoadScene(sceneToEnter);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
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

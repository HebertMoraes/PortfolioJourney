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

    // Start is called before the first frame update
    void Start()
    {
        SpawnSystemObj = GameObject.FindGameObjectWithTag("GameController");
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

            GameObject fundoPressToEnter = GameObject.FindGameObjectWithTag("CanvasEnterDoor");
            fundoPressToEnter.GetComponent<Image>().enabled = true;
            fundoPressToEnter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

            PressToEnter = true;
        }
    }

    private void OnTriggerExit(Collider other) {

        GameObject fundoPressToEnter = GameObject.FindGameObjectWithTag("CanvasEnterDoor");
        fundoPressToEnter.GetComponent<Image>().enabled = false;
        fundoPressToEnter.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

        PressToEnter = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public string sceneToEnter;
    private bool pressToEnter;
    private GameObject spawnSystemObj;
    private GameObject boxGUItoShow;

    // Start is called before the first frame update
    void Start()
    {
        spawnSystemObj = GameObject.FindGameObjectWithTag("GameController");

        if (SceneManager.GetActiveScene().name == "Corredor") {
            boxGUItoShow = GameObject.Find("UIEnterDoor");
        } else {
            boxGUItoShow = GameObject.Find("UIExitDoor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pressToEnter) {
            if (Input.GetKeyDown(KeyCode.X)) {
                
                if (SceneManager.GetActiveScene().name == "Corredor"){
                    spawnSystemObj.GetComponent<MudarScene>().mudarSalvarObjs(sceneToEnter);
                } else {
                    SceneManager.LoadScene(sceneToEnter);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            boxGUItoShow.GetComponent<RawImage>().enabled = true;
            boxGUItoShow.transform.GetChild(0).GetComponent<RawImage>().enabled = true;
            boxGUItoShow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;

            pressToEnter = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        boxGUItoShow.GetComponent<RawImage>().enabled = false;
        boxGUItoShow.transform.GetChild(0).GetComponent<RawImage>().enabled = false;
        boxGUItoShow.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;

        pressToEnter = false;
    }
}

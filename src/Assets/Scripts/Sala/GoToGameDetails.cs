using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GoToGameDetails : MonoBehaviour
{
    private bool pressToEnter;
    private GameObject boxGUItoShow;

    [DllImport("__Internal")]
    private static extern void ScrollDownGameDetail(int number);

    // Start is called before the first frame update
    void Start()
    {
        boxGUItoShow = GameObject.Find("UISeeGameDetails");
    }

    // Update is called once per frame
    void Update()
    {
        if (pressToEnter) {
            if (Input.GetKeyDown(KeyCode.X)) {
                ScrollDownGameDetail(SceneManager.GetActiveScene().buildIndex);
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

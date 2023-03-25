using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaHudManipulation : MonoBehaviour
{
    private bool legendaOn;
    private float tempoComLegendaOn;
    private float tempoMaxComLegendaOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (legendaOn)
        {
            if (tempoComLegendaOn >= tempoMaxComLegendaOn)
            {
                DesativarLegenda();
            }
            tempoComLegendaOn += Time.deltaTime;
        }
    }

    public void AtivarLegenda(float tempoMaxComLegendaOn, string txtLegenda)
    {
        gameObject.GetComponent<RawImage>().enabled = true;
        transform.GetChild(0).GetComponent<RawImage>().enabled = true;

        transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = txtLegenda;
        legendaOn = true;
        tempoComLegendaOn = 0;
        this.tempoMaxComLegendaOn = tempoMaxComLegendaOn;
    }

    private void DesativarLegenda()
    {
        legendaOn = false;
        tempoComLegendaOn = 0;
        gameObject.GetComponent<RawImage>().enabled = false;
        transform.GetChild(0).GetComponent<RawImage>().enabled = false;

        transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}

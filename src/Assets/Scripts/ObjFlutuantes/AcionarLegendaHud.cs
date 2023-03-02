using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionarLegendaHud : MonoBehaviour
{
    public string txtLegenda;
    public float tempoMaxComLegendaOn;
    private LegendaHudManipulation legManipulation;

    // Start is called before the first frame update
    void Start()
    {
        legManipulation = GameObject.Find("Canvas").transform.GetChild(2).gameObject.GetComponent<LegendaHudManipulation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarLegenda()
    {
        legManipulation.AtivarLegenda(tempoMaxComLegendaOn, txtLegenda);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCortinas : MonoBehaviour
{
    [HideInInspector]
    public bool abertas;
    public float velMovCortinas;
    public float xToMove;
    public AudioSource audioSourceVideo;
    private Transform cortinaLeft;
    private Transform cortinaRight;

    // Start is called before the first frame update
    void Start()
    {
        cortinaLeft = transform.GetChild(0);
        cortinaRight = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (cortinaLeft.position.x <= -xToMove) {
            if (!abertas) {
                audioSourceVideo.Play();
            }
            abertas = true;
        } else {

            cortinaLeft.Translate(new Vector3(
                -velMovCortinas * Time.deltaTime, 
                0, 
                0
            ));

            cortinaRight.Translate(new Vector3(
                velMovCortinas * Time.deltaTime, 
                0, 
                0
            ));
        }
    }
}

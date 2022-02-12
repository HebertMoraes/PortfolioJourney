using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManipulation : MonoBehaviour
{
    public List<Texture2D> imagensVideos;
    public List<float> tempoCadaImagem;

    private Material materialImg;
    private float tempoEsperaImg;
    private int imgAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        materialImg = GetComponent<Renderer>().material;
        materialImg.mainTexture = imagensVideos[0];
        imgAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (imgAtual <= imagensVideos.Capacity - 1) {

            if (tempoEsperaImg >= tempoCadaImagem[imgAtual]) {
                materialImg.mainTexture = imagensVideos[imgAtual];
                imgAtual += 1;
                tempoEsperaImg = 0;
            }

            tempoEsperaImg += Time.deltaTime;
        } else {
            //acabou o video
        }
    }
}

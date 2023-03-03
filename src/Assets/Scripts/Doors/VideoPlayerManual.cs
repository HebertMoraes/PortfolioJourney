using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayerManual : MonoBehaviour
{
    public bool loopPingPong;
    public bool loopNormal;
    public List<Texture2D> imagensVideos;
    public List<float> tempoCadaImagem;
    private Material materialImg;
    private float tempoEsperaImg;
    private int imgAtual;
    private bool progressaoDeImagemCrescente = true;

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
        if ((progressaoDeImagemCrescente && imgAtual < imagensVideos.Capacity) || (!progressaoDeImagemCrescente && imgAtual > 0))
        {
            if (tempoEsperaImg >= tempoCadaImagem[imgAtual])
            {
                materialImg.mainTexture = imagensVideos[imgAtual];
                if (progressaoDeImagemCrescente)
                {
                    imgAtual += 1;
                }
                else
                {
                    imgAtual -= 1;
                }

                tempoEsperaImg = 0;
            }

            tempoEsperaImg += Time.deltaTime;
        }
        else
        {
            if (loopPingPong)
            {
                progressaoDeImagemCrescente = false;
                imgAtual = imagensVideos.Capacity - 2;
                tempoEsperaImg = 0;
            }
            else if (loopNormal)
            {
                progressaoDeImagemCrescente = true;
                imgAtual = 0;
                tempoEsperaImg = 0;
            }
        }
    }
}

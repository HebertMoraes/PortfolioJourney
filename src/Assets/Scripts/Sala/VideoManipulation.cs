using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManipulation : MonoBehaviour
{
    public List<Texture2D> imagensVideos;
    public List<float> tempoCadaImagem;
    // public MovCortinas movCortinas;
    public Animator cortinasAnim;
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
        // if (movCortinas.abertas)
        if (cortinasAnim.GetBool("aberto"))
        {
            if (imgAtual < imagensVideos.Capacity)
            {
                if (tempoEsperaImg >= tempoCadaImagem[imgAtual])
                {
                    materialImg.mainTexture = imagensVideos[imgAtual];
                    imgAtual += 1;
                    tempoEsperaImg = 0;
                }

                tempoEsperaImg += Time.deltaTime;
            }
            else
            {
                //acabou o video
            }
        }
    }
}

//CODIGO ANTIGO PARA TENTAR FAZER COM QUE AS IMAGENS CARREGASSEM ANTES, E DEPOIS COM ELAS 
//CARREGADAS, ERA SÓ BOTAR NA TEXTURA DA TELA, MAS PRA ISSO PRECISA SER FEITO EM UMA 
//SCENE DE CARREGAMENTO MESMO, COM ROUTINES https://www.youtube.com/watch?v=3I5d2rUJ0pE
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManipulation : MonoBehaviour
{
    public int numeroImagens;
    public List<float> tempoCadaImagem;
    private List<Texture2D> imagensVideos;

    private Material materialImg;
    private float tempoEsperaImg;
    private int imgAtual;
    
    // Start is called before the first frame update
    void Start()
    {
        imagensVideos = new List<Texture2D>();
        int i = 0;
        //CARREGAR AS IMAGENS, numeroImagens + 1 para incluir o 0 de indice
        for (int j = 0; j < numeroImagens + 1; j++)
        {
            Texture2D texturaCarregada = Resources.Load("Images/Salas/"+ i.ToString()) as Texture2D;
            imagensVideos.Add(texturaCarregada);
            i++;
        }
        materialImg = GetComponent<Renderer>().material;
        materialImg.mainTexture = imagensVideos[0];
        imgAtual = 0;
    }

    // Update is called once per frame/
    void Update()
    {
        if (imgAtual < imagensVideos.Capacity) {

            if (tempoEsperaImg >= tempoCadaImagem[imgAtual]) {
                materialImg.mainTexture = imagensVideos[imgAtual];
                imgAtual += 1;
                tempoEsperaImg = 0;
            }
            
            tempoEsperaImg += Time.deltaTime;
            Debug.Log("tempo na Img atual: " + tempoEsperaImg + " imagemAtual: " + imgAtual);
        } else {
            //acabou o video
        }
    }
}
*/
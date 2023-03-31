using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MudarScene : MonoBehaviour
{
    public GameObject objFlutuantePrefab;
    public GameObject lampadaPrefab;
    private GameObject[] listaCorredores;

    //talvez precisa ser no start e não awake
    private void Awake()
    {
        listaCorredores = GameObject.FindGameObjectsWithTag("Corredor");

        //Se não for a primeira vez
        if (SaveCorredor.possuiSave)
        {
            int i = 0;
            foreach (GameObject corredor in listaCorredores)
            {
                corredor.transform.position = SaveCorredor.posCorredores[i];
                corredor.transform.rotation = SaveCorredor.rotationCorredores[i];

                corredor.transform.GetChild(4).position = SaveCorredor.posDoors[i];
                corredor.transform.GetChild(4).rotation = SaveCorredor.rotationDoors[i];

                //caso o que está salvo seja o dummy, destruir o que está no momento para spawnar o dummy no lugar dele, 
                //com a nova position e rotation
                if (!SaveCorredor.dummyOrNoObjFlutuante[i])
                {
                    GameObject currentObjFlutuante = corredor.transform.GetChild(5).gameObject;

                    if (currentObjFlutuante.name.Contains("DummyObjFlutuante"))
                    {
                        // Transform transformObjFlutuante = currentObjFlutuante.transform;
                        Destroy(currentObjFlutuante);
                        //precisa saber o tipo correto de objFlutuante
                        Instantiate(objFlutuantePrefab,
                            SaveCorredor.posObjFlutuantes[i],
                            SaveCorredor.rotationObjFlutuantes[i],
                            corredor.transform
                        );
                    }
                    else
                    {
                        //aqui pode acontecer de o objFlutuante reposicionado seja diferente do que era no save, 
                        //vai vir pelo o que está padrã no inicio da scene, descrito no editor
                        corredor.transform.GetChild(5).position = SaveCorredor.posObjFlutuantes[i];
                        corredor.transform.GetChild(5).rotation = SaveCorredor.rotationObjFlutuantes[i];
                    }

                }
                else
                {
                    corredor.transform.GetChild(5).position = SaveCorredor.posObjFlutuantes[i];
                    corredor.transform.GetChild(5).rotation = SaveCorredor.rotationObjFlutuantes[i];
                }

                //caso o que está salvo seja o dummy, destruir o que está no momento para spawnar o dummy no lugar dele, 
                //com a nova position e rotation
                if (!SaveCorredor.dummyOrNoLampada[i])
                {
                    GameObject currentLampada = corredor.transform.GetChild(3).gameObject;

                    if (currentLampada.name.Contains("DummyLampada"))
                    {
                        // Destroy(currentLampada);
                        //precisa saber o tipo correto de objFlutuante
                        Instantiate(lampadaPrefab,
                            SaveCorredor.posLampada[i],
                            SaveCorredor.rotationLampada[i],
                            corredor.transform
                        );
                    }
                    else
                    {
                        //aqui pode acontecer de a lampada reposicionado seja diferente do que era no save, 
                        //vai vir pelo o que está padrã no inicio da scene, descrito no editor
                        corredor.transform.GetChild(3).position = SaveCorredor.posLampada[i];
                        corredor.transform.GetChild(3).rotation = SaveCorredor.rotationLampada[i];
                    }
                }
                else
                {
                    corredor.transform.GetChild(3).position = SaveCorredor.posLampada[i];
                    corredor.transform.GetChild(3).rotation = SaveCorredor.rotationLampada[i];
                }

                i += 1;
            }

            GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(
                    SaveCorredor.posJogador, SaveCorredor.rotationJogador);

            //apagar tudo das listas do save, resetar
            SaveCorredor.posCorredores.Clear();
            SaveCorredor.rotationCorredores.Clear();

            SaveCorredor.posDoors.Clear();
            SaveCorredor.rotationDoors.Clear();

            SaveCorredor.posObjFlutuantes.Clear();
            SaveCorredor.rotationObjFlutuantes.Clear();

            SaveCorredor.posLampada.Clear();
            SaveCorredor.rotationLampada.Clear();

            SaveCorredor.dummyOrNoObjFlutuante.Clear();
            SaveCorredor.dummyOrNoLampada.Clear();
            
            SaveCorredor.possuiSave = false;
        }
    }

    //pelo o que eu vi, as vezes buga não sei porque e o jogador não volta na sua última posição
    //quando entrou na porta, ele fica na posição inicial do editor, então abaixo é a tentativa 
    //para corrigir
    //DEU CERTO, ISSO CORRIGIU, PORTANTO, SIGNIFICA QUE OS OUTROS OBJETOS QUE ESTÃO SENDO 
    //ALTERADOS SUAS POSIÇÕES PARA OS DO SAVE PODEM NÃO ESTAR CARREGANDO ASSIM COMO O JOGADOR
    //E ASSSIM, VOLTANDO AOS DADOS DO EDITOR, POSIVEL SOLUÇÃO: UM MONOBEHAVIOR GERAL EM CADA UM
    //DOS PREFABS DESSES OBJETOS E LÁ É QUE FAZ O LOAD DE SUAS POSIÇÕES E ROTAÇÕES QUANDO SE DEVE.
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(
                    SaveCorredor.posJogador, SaveCorredor.rotationJogador);
    }

    public void mudarSalvarObjs(string sceneToEnter)
    {
        listaCorredores = GameObject.FindGameObjectsWithTag("Corredor");

        foreach (GameObject corredor in listaCorredores)
        {
            //salvar os dados dos corredores e seus objetos filhos
            //nas listas do save

            SaveCorredor.posCorredores.Add(corredor.transform.position);
            SaveCorredor.rotationCorredores.Add(corredor.transform.rotation);

            SaveCorredor.posDoors.Add(corredor.transform.GetChild(4).position);
            SaveCorredor.rotationDoors.Add(corredor.transform.GetChild(4).rotation);

            //aqui precisa de uma verificação para ver se é o dummy ou não, e tratar no método Awake lá em cima 
            //a partir disso, sendo: se for dummy, destruir o que está no seu lugar e spawnar o dummy
            SaveCorredor.posObjFlutuantes.Add(corredor.transform.GetChild(5).position);
            SaveCorredor.rotationObjFlutuantes.Add(corredor.transform.GetChild(5).rotation);
            if (corredor.transform.GetChild(5).gameObject.name.Contains("DummyObjFlutuante"))
            {
                SaveCorredor.dummyOrNoObjFlutuante.Add(true);
            }
            else
            {
                SaveCorredor.dummyOrNoObjFlutuante.Add(false);
            }
            //aqui precisa de uma verificação para ver se é o dummy ou não, e tratar no método Awake lá em cima 
            //a partir disso, sendo: se for dummy, destruir o que está no seu lugar e spawnar o dummy
            SaveCorredor.posLampada.Add(corredor.transform.GetChild(3).position);
            SaveCorredor.rotationLampada.Add(corredor.transform.GetChild(3).rotation);
            if (corredor.transform.GetChild(3).gameObject.name.Contains("DummyLampada"))
            {
                SaveCorredor.dummyOrNoLampada.Add(true);
            }
            else
            {
                SaveCorredor.dummyOrNoLampada.Add(false);
            }
        }

        SaveCorredor.posJogador = GameObject.FindGameObjectWithTag("Player").transform.position;
        SaveCorredor.rotationJogador = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        SaveCorredor.possuiSave = true;
        SceneManager.LoadScene(sceneToEnter);
    }
}

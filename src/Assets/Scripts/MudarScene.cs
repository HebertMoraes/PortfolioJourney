using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MudarScene : MonoBehaviour
{
    private GameObject[] listaCorredores;

    //talvez precisa ser no start e não awake
    private void Awake() {
        
        listaCorredores = GameObject.FindGameObjectsWithTag("Corredor");

        //Se não for a primeira vez
        if (SaveCorredor.possuiSave) 
        {
            int i = 0;
            foreach (GameObject corredor in listaCorredores)
            {
                //reposicionar os corredores e seus objetos filhos
                //para os dados das listas do save
                corredor.transform.position = SaveCorredor.posCorredores[i];
                corredor.transform.rotation = SaveCorredor.rotationCorredores[i];

                corredor.transform.GetChild(3).position = SaveCorredor.posDoors[i];
                corredor.transform.GetChild(3).rotation = SaveCorredor.rotationDoors[i];

                corredor.transform.GetChild(4).position = SaveCorredor.posObjFlutuantes[i];
                corredor.transform.GetChild(4).rotation = SaveCorredor.rotationObjFlutuantes[i];

                i+=1;
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
        } 
    }

    //pelo o que eu vi, as vezes buga não sei porque e o jogador não volta na sua última posição
    //quando entrou na porta, ele fica na posição inicial do editor, então abaixo é a tentativa 
    //para corrigir
    //DEU CERTO, ISSO CORRIGIU, PORTANTO, SIGNIFICA QUE OS OUTROS OBJETOS QUE ESTÃO SENDO 
    //ALTERADOS SUAS POSIÇÕES PARA OS DO SAVE PODEM NÃO ESTAR CARREGANDO ASSIM COMO O JOGADOR
    //E ASSSIM, VOLTANDO AOS DADOS DO EDITOR, POSIVEL SOLUÇÃO: UM MONOBEHAVIOR GERAL EM CADA UM
    //DOS PREFABS DESSES OBJETOS E LÁ É QUE FAZ O LOAD DE SUAS POSIÇÕES E ROTAÇÕES QUANDO SE DEVE.
    private void Start() {
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

            SaveCorredor.posDoors.Add(corredor.transform.GetChild(3).position);
            SaveCorredor.rotationDoors.Add(corredor.transform.GetChild(3).rotation);

            SaveCorredor.posObjFlutuantes.Add(corredor.transform.GetChild(4).position);
            SaveCorredor.rotationObjFlutuantes.Add(corredor.transform.GetChild(4).rotation);
        }
        
        SaveCorredor.posJogador = GameObject.FindGameObjectWithTag("Player").transform.position;
        SaveCorredor.rotationJogador = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        SaveCorredor.possuiSave = true;
        SceneManager.LoadScene(sceneToEnter);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFlutuanteManipulation : MonoBehaviour
{
    
    public List<GameObject> listaTodosObj;
    private int vezesObjSpawnada;
    private List<int> indicesJaEscolhidosParaObj;
    private bool indiceEscolhidoAprovado;
    private int indiceEscolhido;

    // Start is called before the first frame update
    void Start()
    {
        //acredito que essa lista diferente das outras precise instanciar, 
        //pois não está sendo passado valor no Unity Editor (sim testei)
        indicesJaEscolhidosParaObj = new List<int>();
    }

    public GameObject EscolherObjSpawnar() 
    {
        //apenas para os primeiros obj, isso para que os primeiras apareçam 
        //na ordem que eu quero
        if (vezesObjSpawnada + 1 <= listaTodosObj.Count) {
            int i = vezesObjSpawnada;
            vezesObjSpawnada +=1;
            return listaTodosObj[i];
        } 
        else {
            while (!indiceEscolhidoAprovado) {
                indiceEscolhido = Random.Range(0, listaTodosObj.Count);

                if (!indicesJaEscolhidosParaObj.Contains(indiceEscolhido)) {
                    indicesJaEscolhidosParaObj.Add(indiceEscolhido);
                    indiceEscolhidoAprovado = true;
                }
            }
            
            if (indicesJaEscolhidosParaObj.Count >= listaTodosObj.Count) {

                for (int p = listaTodosObj.Count - 1; p >= 0; p--) {
                    indicesJaEscolhidosParaObj.RemoveAt(p);
                }
            }

            indiceEscolhidoAprovado = false;
            return listaTodosObj[indiceEscolhido];
        }
    }
}

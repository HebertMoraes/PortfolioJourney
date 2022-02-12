using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManipulation : MonoBehaviour
{
    public List<GameObject> listaTodasDoors;

    private int numEscolherParede;

    private int vezesDoorSpawnada;
    private List<int> indicesJaEscolhidosParaDoor;
    private bool indiceEscolhidoAprovado;
    private int indiceEscolhido;

    private void Start() {
        //acredito que essa lista diferente das outras precise instanciar, 
        //pois não está sendo passado valor no Unity Editor (sim testei)
        indicesJaEscolhidosParaDoor = new List<int>();

        numEscolherParede = 0;
    }

    //DESSA FORMA OS PRIMEIROS CORREDORES ESTARÃO EM ORDEM ESCOLHIDOS NA LISTA NO EDITOR DO 
    //UNITY, QUE POR SUA VEZ ESTARÁ EM ORDEM DE DATA DOS PROJETOS, MAS DEPOIS QUE ACABAR, 
    //A LISTA ESTARÁ ALEATÓRIO E ASSIM, AS PORTAS/PROJETOS APARECERAM RONDOMICAMENTE
    public GameObject EscolherPortaSpawnar () {
        
        //apenas para as primeiras doors, isso para que as primeiras apareçam 
        //na ordem que eu quero
        if (vezesDoorSpawnada + 1 <= listaTodasDoors.Count) {
            int i = vezesDoorSpawnada;
            vezesDoorSpawnada +=1;
            return listaTodasDoors[i];
        } 
        else {
            while (!indiceEscolhidoAprovado) {
                indiceEscolhido = Random.Range(0, listaTodasDoors.Count);

                if (!indicesJaEscolhidosParaDoor.Contains(indiceEscolhido)) {
                    indicesJaEscolhidosParaDoor.Add(indiceEscolhido);
                    indiceEscolhidoAprovado = true;
                }
            }
            
            if (indicesJaEscolhidosParaDoor.Count >= listaTodasDoors.Count) {

                for (int p = listaTodasDoors.Count - 1; p >= 0; p--) {
                    indicesJaEscolhidosParaDoor.RemoveAt(p);
                }
            }

            indiceEscolhidoAprovado = false;
            return listaTodasDoors[indiceEscolhido];
        }
    }

    public int EscolherParede() {
        if (numEscolherParede == 0) {
            numEscolherParede += 1;
            return numEscolherParede;
        }
        if (numEscolherParede == 1) {
            numEscolherParede -= 1;
            return numEscolherParede;
        }
        return numEscolherParede;
    }
}

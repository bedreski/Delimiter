using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisado 

public class Gerador : MonoBehaviour {

    public GameObject caixa; 

    public void GerandoCaixa() {

        GameObject caixaObj = Instantiate(caixa); 

        Vector3 objeto = transform.position; 

        objeto.z = 0f; 

        caixaObj.transform.position = objeto; 

    }
}

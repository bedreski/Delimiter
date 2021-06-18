﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisado 

public class Gerador : MonoBehaviour {

    public GameObject parenteses;
    public GameObject chaves;
    public GameObject colchetes;
    public GameObject caixa; 
    ControleJogo cj; 
    [HideInInspector]
    public int escolhaCaixa; 

    void Start() {

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
    }

    //Chooses which box GameObject will be generated
    public void GerandoCaixa() {

        GameObject caixaObj; 
        
        switch(escolhaCaixa) {

            case 1:
                caixaObj = Instantiate(parenteses);
            break; 

            case 2:
                caixaObj = Instantiate(chaves);
            break; 

            case 3:
                caixaObj = Instantiate(colchetes);
            break; 

            default:
                caixaObj = Instantiate(caixa); 
            break; 
        } 

        Vector3 objeto = transform.position; 

        objeto.z = 0f; 

        caixaObj.transform.position = objeto;
    }
}
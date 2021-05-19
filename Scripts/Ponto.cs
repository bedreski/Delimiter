﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Revisado

public class Ponto : MonoBehaviour {

    public GameObject ponto; 
    public GameObject fimExp; 
    private Rigidbody2D rigidB; 
    public static Ponto instancia; 
    ControleJogo cj; 
    private Expressao e; 
    private int i; 
    public Text texto;
    public string expressao;
    private string tagExpressao; 
    private float maxDistanciaDelta; 


    void Awake() {

        InstanciaRb(); 
    }

    void Start() {

        InstanciaPonto();

        e = GameObject.Find("expressao").GetComponent<Expressao>();
        ConverteExpressao();
        expressao = e.expressao;

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>(); 

        i = 0; 

        Debug.Log("Tag da expressão: " + e.tag);
        IdentificaExpresssao();
    }


    void IdentificaExpresssao() {

        tagExpressao = e.tag; 

        switch(tagExpressao) {

            case "expressao1":
                maxDistanciaDelta = 0.65f; 
            break; 

            case "expressao2":
                maxDistanciaDelta = 1.115f;
            break; 

            case "expressao3": 
                maxDistanciaDelta = 0.59f;
            break; 

            case "expressao4": 
                maxDistanciaDelta = 0.65f;
            break; 

        }
    }

   
    public void MovePonto() {

        ponto.transform.position = Vector3.MoveTowards(ponto.transform.position, fimExp.transform.position, maxDistanciaDelta);

        Debug.Log("v[" + i + "]  = " + expressao[i]); 

        e.DelimitadorAbertura(expressao[i]);
        e.DelimitadorFechamento(expressao[i]);

        if(e.GetEncAbertura()) {

            cj.abertura = e.GetDelimAbertura(); 
            cj.GerarCaixa();
        
        } else {

            if(e.GetEncFechamento()) {

                Debug.Log("Encontrou delimitador de fechamento.");
                cj.fechamento = e.GetDelimFechamento(); 
            }
        }
        
        if(i % 2 == 0)
            i += 2; 
        else
            i += 0;
    }



    void ConverteExpressao() {

        e.ExpressaoString(texto);
    }



    void InstanciaRb() {

        rigidB = GetComponent<Rigidbody2D>();
        rigidB.gravityScale = 0f;  
    }



    void InstanciaPonto() {

        if(instancia == null) {

            instancia = this;
        }
    }

}

using System.Collections;
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


    void Awake() {

        InstanciaRb(); 
    }

    void Start() {

        InstanciaPonto();

        e = GameObject.Find("expressao").GetComponent<Expressao>();
        ConverteExpressao();
        expressao = e.expressao;
        Debug.Log("Expressao no Ponto: " + expressao);


        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>(); 

        i = 0; 
    }

   
    public void MovePonto() {

        ponto.transform.position = Vector3.MoveTowards(ponto.transform.position, fimExp.transform.position, 1.112f);

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


/*Função para colocar um valor do transform position para cada expressão em específico. 
    
    --> Switch case ou if
    --> Procurar uma forma de identificar a expressão (tag, nome, componente...)
    --> Colocar um valor para o ponto.transform.position receber 
    --> Essa função será chamada no lugar da linha 53 (ponto.transform.position)

    */

}

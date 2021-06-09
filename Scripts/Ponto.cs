using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System; 
using TMPro; 

//Revisado

public class Ponto : MonoBehaviour {

    public GameObject ponto; 
    public GameObject fimExp; 
    private Rigidbody2D rigidB; 
    public static Ponto instancia; 
    ControleJogo cj; 
    private Expressao e; 
    public int i; 
    //public Text texto;
    public TMP_Text texto; 
    public string expressao;
    private string tagExpressao; 
    private float maxDistanciaDelta; 
    Mensagem m; 


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

        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
    }

    //MaxDistanceDelta is the third argument of MoveTowards function, that moves the location point
    void IdentificaExpresssao() {

        tagExpressao = e.tag; 

        switch(tagExpressao) {

            case "expressao1":
                maxDistanciaDelta = 0.65f; 
            break; 

            case "expressao2":
                maxDistanciaDelta = 1.199f;
            break; 

            case "expressao3": 
                maxDistanciaDelta = 0.59f;
            break; 

            case "expressao4": 
                maxDistanciaDelta = 0.65f;
            break; 

        }
    }

   //Location point responsible for being the index of the string and identify the delimiter character
    public void MovePonto() {

        try {

            ponto.transform.position = Vector3.MoveTowards(ponto.transform.position, fimExp.transform.position, maxDistanciaDelta);

            e.DelimitadorAbertura(expressao[i]);
            e.DelimitadorFechamento(expressao[i]);

            if(e.GetEncAbertura()) {

                cj.abertura = e.GetDelimAbertura(); 
                cj.GerarCaixa();
            
            } else {

                if(e.GetEncFechamento()) {

                    cj.fechamento = e.GetDelimFechamento(); 
                }
            }

            i++; 
            Debug.Log("I em Ponto = " + i); 

        } catch (System.IndexOutOfRangeException e) {

            m.StringParaText("Essa expressão terminou, mas podemos verificar outra :)");
            m.StartCoroutine(m.WaitAndPrint(5f));
            m.StringParaText(" "); 
            m.StartCoroutine(m.WaitAndPrint(0.5f));
            //Debug.Log(e.Message);
            // Set IndexOutOfRangeException to the new exception's InnerException.
            throw new System.ArgumentOutOfRangeException("index parameter is out of range.", e);
        }
    }


    //Turns the Text UI expression in a string expression
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

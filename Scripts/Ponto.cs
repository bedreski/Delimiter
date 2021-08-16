using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System; 
using TMPro; 


public class Ponto : MonoBehaviour {

    public IrParaExpressoes ie;
    public static Ponto instancia;  
    private Rigidbody2D rigidB; 
    public static bool avançou; 
    public GameObject ponto; 
    public GameObject fimExp; 
    private Expressao e; 
    public static int i; 
    public TMP_Text texto; 
    private string tagExpressao; 
    public string expressao;
    private float maxDistanciaDelta; 
    ControleJogo cj; 
    Mensagem m; 
    BotaoPush b;


    void Awake() {

        InstanciaRb(); 
    }

    void Start() {

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>(); 
        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
        b = GameObject.Find("BotaoPush").GetComponent<BotaoPush>();

        ConverteExpressao();

        i = 0; 
        expressao = e.expressao;

        InstanciaPonto();
        IdentificaExpressao();
    }

    //MaxDistanceDelta is the third argument of MoveTowards function, that moves the location point
    void IdentificaExpressao() {

        tagExpressao = e.tag; 

        switch(tagExpressao) {

            case "expressao1":
                maxDistanciaDelta = 0.65f; 
            break; 

            case "expressao2":
                maxDistanciaDelta = 1.2f;
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
                StartCoroutine(m.ExibirMensagem("Delimitador de abertura encontrado. Dê um PUSH!"));
            
            } else {

                if(e.GetEncFechamento()) {

                    cj.fechamento = e.GetDelimFechamento(); 
                    StartCoroutine(m.ExibirMensagem("Delimitador de fechamento encontrado. Dê um POP!"));
                }
            }

            i++;  
            avançou = true;

        } catch (System.IndexOutOfRangeException e) {

            ie.Habilitado(); 
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

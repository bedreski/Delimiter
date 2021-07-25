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

        InstanciaPonto();

        e = GameObject.Find("expressao").GetComponent<Expressao>();
        ConverteExpressao();
        expressao = e.expressao;

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>(); 

        i = 0; 

        IdentificaExpressao();

        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
        b = GameObject.Find("BotaoPush").GetComponent<BotaoPush>();
    }

    //MaxDistanceDelta is the third argument of MoveTowards function, that moves the location point
    void IdentificaExpressao() {

        tagExpressao = e.tag; 

        switch(tagExpressao) {

            case "expressao1":
                maxDistanciaDelta = 0.65f; 
            break; 

            //For x position = -0.4
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
                m.StringParaText("Delimitador de abertura encontrado. Dê um PUSH!");
                StartCoroutine(m.WaitAndPrint(0.5f));
            
            } else {

                if(e.GetEncFechamento()) {

                    cj.fechamento = e.GetDelimFechamento(); 
                    m.StringParaText("Delimitador de fechamento encontrado. Dê um POP!");
                    StartCoroutine(m.WaitAndPrint(0.5f));
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

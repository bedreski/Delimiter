using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using TMPro;


public class ControleJogo : MonoBehaviour {

    public static ControleJogo instancia;
    public IrParaExpressoes ie;
    public Stack <string> pilha = new Stack<string>(); 
    public Stack <Caixa> pilhaCaixas = new Stack<Caixa>();  
    public Gerador gerador; 
    public Expressao e; 
    public Mensagem m; 
    [HideInInspector]
    public Caixa caixa, topo; 
    public Caixa parenteses, chaves, colchetes; 
    BotaoPush bp;
    Ponto p;
    public TMP_Text texto;
    public string fechamento, abertura;
    public string expressao; 
    public int tamanhoExpressao;  
    GameObject go; 
    bool delimitadoresCorrespondentes;   
    

    void Start() {

        e = GameObject.Find("expressao").GetComponent<Expressao>();
        bp = GameObject.Find("BotaoPush").GetComponent<BotaoPush>();
        p = GameObject.Find("pontoDeLocalizacao4dot5").GetComponent<Ponto>();

        expressao = e.expressao;
        tamanhoExpressao = expressao.Length; 

        ConverteExpressao();
        InstanciaScript();

    }



    void ConverteExpressao() {

        e.ExpressaoString(texto);
    }



    public void VerificaExpressao() { 

        ComparaDelimitadores(abertura, fechamento);

        if(!delimitadoresCorrespondentes) {

            m.StringParaText("Expressão incorreta!");
            StartCoroutine(m.WaitAndPrint(1f));
            StartCoroutine(TempoEspera());
        } 
    }

    public IEnumerator TempoEspera() {

        yield return new WaitForSecondsRealtime(2);
        ie.Habilitado();
    }


    //Validates the delimiters 
    public void ComparaDelimitadores(string a, string f) {


        if(a == "[" && f == "]")  {

            m.StringParaText("Colchetes: ok");
            delimitadoresCorrespondentes = true; 
            StartCoroutine(m.WaitAndPrint(0.5f)); 
            Destroy(topo.gameObject, 1.5f);
            
        } else {

            if(a == "(" && f == ")") {

                m.StringParaText("Parenteses: ok");
                delimitadoresCorrespondentes = true; 
                StartCoroutine(m.WaitAndPrint(0.5f));
                Destroy(topo.gameObject, 1.5f);
        
            } else {

                if(a == "{" && f == "}") {

                    m.StringParaText("Chaves: ok");
                    delimitadoresCorrespondentes = true; 
                    StartCoroutine(m.WaitAndPrint(0.5f));
                    Destroy(topo.gameObject, 1.5f);
                    
                } else {

                    delimitadoresCorrespondentes = false;  
                    
                } 
            } 
        }
    }


    //Defines which box will be generated, according with the delimiter found
    public void DefineCaixa() {

        if(abertura == "(") {

            gerador.GerandoCaixa(1); 
            caixa = parenteses; 

        } else {

            if(abertura == "{") {

                gerador.GerandoCaixa(2);
                caixa = chaves; 

            } else {

                if(abertura == "[") {

                    gerador.GerandoCaixa(3);
                    caixa = colchetes; 
                }
            }
        }
    }

    //Defines the box and generate the new box with the found delimiter
    public void GerarCaixa() {

        Invoke("DefineCaixa", 0.7f); 
    }


    //Places the delimiter and the box GameObject in its stacks
    public void Empilha() {
        
        pilha.Push(abertura);
        pilhaCaixas.Push(caixa);
    }


    //Does a Pop operation in the characters stack
    public void DesempilhaDelimitador() {

        abertura = pilha.Pop();
    }


    //Does a Pop operation in the box GameObject stack and destroy the respective GameObject
    public void DesempilhaCaixa() {

        topo = pilhaCaixas.Pop();  
        topo.UiDesempilhaCaixa(); 
    }


    //Returns the number of elements on the stack
    public int QuantidadeElementosPilha() {

        return pilha.Count; 
    }



    void InstanciaScript() {

        if(instancia == null) {
            instancia = this; 
        }
    }

}

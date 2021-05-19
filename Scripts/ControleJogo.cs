using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Revisado 

public class ControleJogo : MonoBehaviour {

    public static ControleJogo instancia;
    public Stack <string> pilha = new Stack<string>(); 
    public Stack <Caixa> pilhaCaixas = new Stack<Caixa>();  
    public Gerador gerador; 
    public string fechamento; 
    public string abertura; 
    public Caixa caixa; 
    private Caixa c; 
    public Expressao e;

    void Start() {

        InstanciaScript();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
    }


    //Revisado -- adicionar os outros tratamentos
    public void VerificaExpressao() { 

        ComparaDelimitadores(abertura, fechamento);
    
    }


    public void ComparaDelimitadores(string a, string f) {

        Debug.Log("Comparando abertura: " + a + " com fechamento: " + f);

        if(a == "[" && f == "]")  {

            //Recurso de interface aqui 
            Debug.Log("Colchetes: ok!");

        } else {

            if(a == "(" && f == ")") {

                Debug.Log("Parenteses: ok!");

            } else {

                if(a == "{" && f == "}") {

                    Debug.Log("Chaves: ok!");

                } else {

                    Debug.Log("Expressão incorreta!");
                } 
            } 
        }
    }

    //Delimitador e GameObject 
    public void Empilha() {
        
        Debug.Log("Caractere sendo empilhado: " + abertura); 
        pilha.Push(abertura);
        //Qual caixa? 
        pilhaCaixas.Push(caixa);
    }


    //Revisar 
    public void DesempilhaDelimitador() {

        abertura = pilha.Pop();
        Debug.Log("Caractere sendo desempilhado: " + abertura);
    }

    //Revisar e desenvolver 
    public void DesempilhaCaixa() {

        Debug.Log("Método DesempilhaCaixa sem funções");
    }


    void ImprimePilha() {

        Debug.Log("Pilha de caracteres:");

        foreach(string caractere in pilha) {

            Debug.Log(caractere);
        }
    }
    

    //vem do script gerador (origem da caixa)
    void NovaCaixa() {

        gerador.GerandoCaixa(); 
    }

    //É chamado no script ponto
    public void GerarCaixa() {

        Invoke("NovaCaixa", 0.7f); 
    }


    void InstanciaScript() {

        if(instancia == null) {
            instancia = this; 
        }
    }

}

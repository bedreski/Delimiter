using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//Revisando 

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
        e = GameObject.Find("exp2").GetComponent<Expressao>();
    }


    public void VerificaExpressao() { 

        if(e.GetEncFechamento() && pilha.Count == 0) {

            Debug.Log("Expressão incorreta!");

        } else {

            ComparaDelimitadores(abertura, fechamento);
        }

    }


    public void ComparaDelimitadores(string a, string f) {

        if(a == "[" && f == "]")  {

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



    public void EmpilhaDelimitador() {

        Debug.Log("Caractere que está sendo empilhado: " + abertura); 
        pilha.Push(abertura); 
    }


    
    public void DesempilhaD() {

        abertura = pilha.Pop();
        Debug.Log("Caractere sendo desempilhado: " + abertura);
    }

    public void EmpilhaCaixa() {

        pilhaCaixas.Push(caixa); 
    }

    public void DesempilhaCaixa() {

        //c = pilhaCaixas.Pop();
        //Destroy(c); 
        Debug.Log("Método sem funções");
    }


    void ImprimePilha() {

        Debug.Log("Pilha:");

        foreach(string caractere in pilha) {

            Debug.Log(caractere);
        } 
    }


    void NovaCaixa() {

        gerador.GerandoCaixa(); 
    }


    public void GerarCaixa() {

        Invoke("NovaCaixa", 0.7f); 
    }


    void InstanciaScript() {

        if(instancia == null) {
            instancia = this; 
        }
    }

}

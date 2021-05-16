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
    }



    /*public void EmpilhaDelimitador() {

        Debug.Log("Caractere sendo empilhado: " + abertura); 
        pilha.Push(abertura); 
    }


    //Revisar 
    public void DesempilhaDelimitador() {

        abertura = pilha.Pop();
        Debug.Log("Caractere sendo desempilhado: " + abertura);
    }

    public void EmpilhaCaixa() {

        pilhaCaixas.Push(caixa); 
    }

    //Revisar e desenvolver 
    public void DesempilhaCaixa() {

        //c = pilhaCaixas.Pop();
        //Destroy(c); 
        Debug.Log("Método DesempilhaCaixa sem funções");
    }*/


    void ImprimePilha() {

        Debug.Log("Pilha de caracteres:");

        foreach(string caractere in pilha) {

            Debug.Log(caractere);
        }

        Debug.Log("Pilha de caixas:");

        foreach(Caixa caixas in pilhaCaixas) {

            Debug.Log(caixas);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

//Revisado 

public class ControleJogo : MonoBehaviour {

    public static ControleJogo instancia;
    public Stack <string> pilha = new Stack<string>(); 
    public Stack <Caixa> pilhaCaixas = new Stack<Caixa>();  
    public Gerador gerador; 
    public string fechamento, abertura; 
    [HideInInspector]
    public Caixa caixa, topo; 
    public Caixa parenteses, chaves, colchetes; 
    public Expressao e; 
    public Mensagem m; 
    public IrParaExpressoes ie; 
    GameObject go; 

    void Start() {

        InstanciaScript();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
 
    }



    //Revisado -- adicionar os outros tratamentos
    public void VerificaExpressao() { 

        ComparaDelimitadores(abertura, fechamento);
    
    }


    //Validates the delimiters 
    public void ComparaDelimitadores(string a, string f) {

        Debug.Log("Comparando abertura: " + a + " com fechamento: " + f);

        if(a == "[" && f == "]")  {

            m.StringParaText("Colchetes: ok");
            StartCoroutine(m.WaitAndPrint(0.5f)); 
            DesempilhaCaixa(); 
            
        } else {

            if(a == "(" && f == ")") {

                m.StringParaText("Parenteses: ok");
                StartCoroutine(m.WaitAndPrint(0.5f));
                DesempilhaCaixa();
        
            } else {

                if(a == "{" && f == "}") {

                    m.StringParaText("Chaves: ok");
                    StartCoroutine(m.WaitAndPrint(0.5f));
                    DesempilhaCaixa();
                    
                } else {

                    m.StringParaText("Expressão incorreta!");
                    StartCoroutine(m.WaitAndPrint(0.5f));
                    ie.Habilitado();
                    
                } 
            } 
        }
    }


    //Defines which box will be generated, according with the delimiter found
    public void DefineCaixa() {

        if(abertura == "(") {

            gerador.escolhaCaixa = 1; 
            caixa = parenteses; 

        } else {

            if(abertura == "{") {

                gerador.escolhaCaixa = 2;
                caixa = chaves; 

            } else {

                if(abertura == "[") {

                    gerador.escolhaCaixa = 3;
                    caixa = colchetes; 
                }
            }
        }
    }

    //Places the delimiter and the box GameObject in its stacks
    public void Empilha() {
        
        Debug.Log("Caractere sendo empilhado: " + abertura); 
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

        Destroy(topo.gameObject, 1); 

        //animation after destroy
    }


    void ImprimePilha() {

        Debug.Log("Pilha de caixas:");

        foreach(Caixa c in pilhaCaixas) {

            Debug.Log("Id: " + c.GetInstanceID());
        }
    }
    
    //Defines the box and generate the new box with the found delimiter
    void NovaCaixa() {

        DefineCaixa();
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

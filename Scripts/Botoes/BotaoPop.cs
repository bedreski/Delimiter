using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisando

public class BotaoPop : MonoBehaviour {

    ControleJogo cj; 
    Ponto p; 
    Expressao e; 
    Mensagem m; 
    GameObject caixa; 

    void Start() {
        
        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
        p = GameObject.Find("pontoDeLocalizacao4dot5").GetComponent<Ponto>();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
    }

    public void Retirar() {


        if(!Ponto.avançou) {

            Debug.Log("Não é possível desempilhar o mesmo caractere duas vezes!"); 

        } else {

            try {

                cj.DesempilhaDelimitador();  
                cj.VerificaExpressao(); 
                Ponto.avançou = false;

            } catch (System.InvalidOperationException e) {

                m.StringParaText("A pilha está vazia! Tente empilhar algo.");
                StartCoroutine(m.WaitAndPrint(0.5f));

                throw new System.InvalidOperationException("Stack is empty now", e);
            }
        }
    }
}

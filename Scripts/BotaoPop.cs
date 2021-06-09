using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisando

public class BotaoPop : MonoBehaviour {

    ControleJogo cj; 
    Ponto p; 
    Expressao e; 
    Mensagem m; 

    void Start() {
        
        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
        p = GameObject.Find("pontoDeLocalizacao4dot5").GetComponent<Ponto>();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
    }

    public void Retirar() {

        if(cj.pilha == null && cj.pilhaCaixas == null) {

            m.StringParaText("A pilha está vazia! Tente empilhar algo.");
            StartCoroutine(m.WaitAndPrint(0.5f));

        } else {

            cj.DesempilhaDelimitador(); 
            //cj.DesempilhaCaixa(); 
            cj.VerificaExpressao(); 
        }
    }


}

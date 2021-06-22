using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Revisado 

public class BotaoPush : MonoBehaviour {

    ControleJogo cj;  
    Expressao e; 
    Mensagem m; 
    Ponto p; 
    BotaoPush b; 

    void Start() {

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
        p = GameObject.Find("pontoDeLocalizacao4dot5").GetComponent<Ponto>();
        b = GameObject.Find("BotaoPush").GetComponent<BotaoPush>(); 
    }

    public void CaixaNaPilha() {

        if(!Ponto.avançou) {

            Debug.Log("Não é possível empilhar o mesmo caractere duas vezes!"); 

        } else {


            if(e.GetEncAbertura()) {

                Caixa.SoltarCaixa(); 
                Caixa.PousoDaCaixa(); 
                cj.Empilha();
                cj.ImprimePilha(); 
                Ponto.avançou = false; 

            } else {

                m.StringParaText("Apenas delimitadores de abertura podem ser empilhados. Avance na expressão!");
                StartCoroutine(m.WaitAndPrint(0.5f));

            } 
        }
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisado 

public class BotaoPush : MonoBehaviour {

    ControleJogo cj;  
    Expressao e; 
    Mensagem m; 
    Ponto p; 

    void Start() {

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
        p = GameObject.Find("pontoDeLocalizacao4dot5").GetComponent<Ponto>();
    }

    public void CaixaNaPilha() {


        if(e.GetEncAbertura()) {

            Caixa.SoltarCaixa(); 
            Caixa.PousoDaCaixa(); 
            cj.Empilha(); 

        } else {

            m.StringParaText("Que pena, apenas delimitadores podem ser empilhados. Avance na expressão!");
            StartCoroutine(m.WaitAndPrint(0.5f));

        } 
    }

}
 
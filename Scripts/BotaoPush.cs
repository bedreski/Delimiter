using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

        if(!Ponto.avançou) {

            m.StringParaText("Não é possível empilhar o mesmo caractere duas vezes!");
            StartCoroutine(m.WaitAndPrint(1f));

        } else {


            if(e.GetEncAbertura()) {

                Caixa.SoltarCaixa(); 
                Caixa.PousoDaCaixa(); 
                cj.Empilha();
                Ponto.avançou = false;  

            } else {

                m.StringParaText("Apenas delimitadores de abertura podem ser empilhados. Avance na expressão!");
                StartCoroutine(m.WaitAndPrint(0.5f));

            } 
        }
    }

    public IEnumerator TempoEspera() {

        yield return new WaitForSecondsRealtime(1);
    }
}
 
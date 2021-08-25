using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BotaoPush : MonoBehaviour {
 
    public bool empilhou = true; 
    ControleJogo cj;  
    Expressao e; 
    Mensagem m; 
    Ponto p; 

    void Start() {
 
        m = GameObject.Find("mensagem").GetComponent<Mensagem>();
        e = GameObject.Find("expressao").GetComponent<Expressao>();
        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
        p = GameObject.Find("pontoDeLocalizacao4dot5").GetComponent<Ponto>();
    }
 
    public void CaixaNaPilha() {

        if(!Ponto.avançou && Ponto.i == 0) {

            StartCoroutine(m.ExibirMensagem("Estamos no início ainda? Então precisamos avançar!")); 

        } else {

            if(!Ponto.avançou) {

                StartCoroutine(m.ExibirMensagem("Não é possível empilhar o mesmo caractere duas vezes!"));

            } else {
                
                if(e.GetEncAbertura()) {

                    Caixa.SoltarCaixa(); 
                    cj.Empilha();
                    StartCoroutine(m.ExibirMensagem("Isso aí, podemos avançar!"));
                    Ponto.avançou = false;  
                    empilhou = true; 

                } else {

                    StartCoroutine(m.ExibirMensagem("Apenas delimitadores de abertura podem ser empilhados. Avance na expressão!"));

                }

            } 
        }
    }

    public IEnumerator TempoEspera() {

        yield return new WaitForSecondsRealtime(1);
    }
}
 
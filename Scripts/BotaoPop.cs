using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BotaoPop : MonoBehaviour {

    public IrParaExpressoes ie;
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



    public void Retirar() {


        if(!Ponto.avançou && !e.GetEncFechamento()) {

            StartCoroutine(m.ExibirMensagem("Ainda não! Encontre um delimitador de fechamento para poder dar um POP!"));

        } else {

            if(!Ponto.avançou) {

                StartCoroutine(m.ExibirMensagem("Não é possível desempilhar o mesmo caractere duas vezes!"));

            } else {

                try {

                    if(e.GetEncFechamento()) {

                        cj.DesempilhaDelimitador();  
                        cj.DesempilhaCaixa(); 
                        cj.VerificaExpressao(); 
                        StartCoroutine(m.ExibirMensagem("Isso aí, podemos avançar!"));
                        Ponto.avançou = false;

                        if(Ponto.i == cj.tamanhoExpressao && cj.QuantidadeElementosPilha() != 0) {

                            StartCoroutine(cj.TempoEspera());
                            StartCoroutine(m.ExibirMensagem("Expressão incorreta!")); 

                        } else {

                            if(Ponto.i == cj.tamanhoExpressao && cj.QuantidadeElementosPilha() == 0) {

                                StartCoroutine(m.ExibirMensagem("Expressão correta!")); 
                                StartCoroutine(TempoEspera());
                            }
                        }
                        
                    } else {

                        StartCoroutine(m.ExibirMensagem("Apenas delimitadores de fechamento podem ser desempilhados!"));
                    }

                } catch (System.InvalidOperationException e) {

                    StartCoroutine(m.ExibirMensagem("A pilha está vazia! Tente empilhar algo."));

                    throw new System.InvalidOperationException("Stack is empty now", e);
                }

            }

        }
    }

    public IEnumerator TempoEspera() {

        yield return new WaitForSecondsRealtime(2);
        ie.Habilitado();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisado 

public class BotaoPush : MonoBehaviour {

    ControleJogo cj; 

    void Start() {

        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
    }

    public void CaixaNaPilha() {

        Caixa.SoltarCaixa(); 
        Caixa.PousoDaCaixa(); 
        cj.EmpilhaDelimitador();
        cj.EmpilhaCaixa(); 
    }

}
 
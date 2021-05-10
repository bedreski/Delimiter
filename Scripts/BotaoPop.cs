using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Revisando

public class BotaoPop : MonoBehaviour {

    ControleJogo cj; 

    void Start() {
        
        cj = GameObject.Find("ControleDoJogo").GetComponent<ControleJogo>();
    }

    public void Retirar() {

        cj.DesempilhaD(); 
        cj.DesempilhaCaixa(); 
        cj.VerificaExpressao();
    }


}

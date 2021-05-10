using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System; 

//Revisando

public class Expressao : MonoBehaviour {

    public string expressao; 
    private string abertura; 
    private string fechamento; 
    private bool encontrouAbertura; 
    private bool encontrouFechamento; 
    public static Expressao i; 

    void Start() {

        InstanciaExp();  
    }

    void Update() {

    }

    public void ExpressaoString(Text e) {

        expressao = e.text;
        
    }


    void InstanciaExp() {

        if(i == null)
            i = this; 
    }


    public void DelimitadorAbertura(char exp) {

        switch(exp) {

            case '(': 
                abertura = exp.ToString();
                encontrouAbertura = true; 
            break; 

            case '{':
                abertura = exp.ToString(); 
                encontrouAbertura = true; 
            break; 

            case '[':
                abertura = exp.ToString(); 
                encontrouAbertura = true; 
            break; 

            default:
                abertura = null; 
                encontrouAbertura = false;
            break; 
        }
    }

    public void DelimitadorFechamento(char exp) {

        switch(exp) {

            case ')':  
                encontrouFechamento = true;
                fechamento = exp.ToString();
            break; 

            case '}':
                encontrouFechamento = true; 
                fechamento = exp.ToString();
            break; 

            case ']':
                encontrouFechamento = true; 
                fechamento = exp.ToString();
            break; 

            default:
                encontrouFechamento = false; 
                fechamento = null;
            break; 
        }
    }

    
    //Adicionar getters e setter de acordo com C#
    public bool GetEncFechamento() {

        return encontrouFechamento; 
    }

    public bool GetEncAbertura() {

        return encontrouAbertura; 
    }

    public string GetDelimAbertura() {

        return abertura; 
    }

    public string GetDelimFechamento() {

        return fechamento; 
    }


}

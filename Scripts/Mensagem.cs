using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Mensagem : MonoBehaviour {


    public Text texto; 

    // suspend execution for waitTime seconds
    public IEnumerator ExibirMensagem(string t) {

        texto.text = t;
        yield return new WaitForSeconds(4);
        texto.text = " "; 
    }

    public void StringParaText(string t) {

        texto.text = t; 
    }
   
}

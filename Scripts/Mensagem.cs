using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Mensagem : MonoBehaviour {


    public Text txt; 

    // suspend execution for waitTime seconds
    public IEnumerator WaitAndPrint(float tempo) {

        yield return new WaitForSeconds(tempo);
    }

    public void StringParaText(string t) {

        txt.text = t; 
    }
   
}

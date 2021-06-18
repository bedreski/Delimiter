using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Mensagem : MonoBehaviour {

    //Mudar pra TMP
    public Text txt; 

    // suspend execution for waitTime seconds
    public IEnumerator WaitAndPrint(float tempo) {

        yield return new WaitForSeconds(2.0f);
        print("WaitAndPrint " + Time.time);
    }

    public void StringParaText(string t) {

        txt.text = t; 
    }
   
}

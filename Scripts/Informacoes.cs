using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacoes : MonoBehaviour
{
    
    public GameObject info; 
    public GameObject infoTexto; 
  

    public void ExibirInformacao() {

        infoTexto.SetActive(true); 
    }

    public void FecharInformacao() {

        infoTexto.SetActive(false); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour {

    public GameObject[] slides; 
    public static int i = 0; 

    void Awake() {

        slides[0].SetActive(true); 

    }

    public void TrocarSlide() {

       if(i < slides.Length - 1) {

           slides[i].SetActive(false); 
           i++;  
           slides[i].SetActive(true); 

        } else {

            slides[i].SetActive(true); 
        }
        
    }

    public void Voltar() {

        if(i > 0) {

           slides[i].SetActive(false); 
           i--; 
           slides[i].SetActive(true); 

        } else {

            slides[i].SetActive(true); 
        }
    }
}

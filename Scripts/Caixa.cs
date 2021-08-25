using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Caixa : MonoBehaviour {

    private static Rigidbody2D rbCaixa; 
    public static bool ignorarColisao = false; 
    public static Caixa referencia;
    static AudioSource audioSource; 
    public AudioClip sound;

    void Awake() {

        InstanciaRb(); 
    }


    void Start() {

        InstanciaScript(); 
        ControleJogo.instancia.caixa = this; 
        audioSource = GetComponent<AudioSource>();
    }


    void InstanciaRb() {

        rbCaixa = GetComponent<Rigidbody2D>();
        rbCaixa.gravityScale = 0f;  
    }


    void InstanciaScript() {

        if(referencia == null) {
            referencia = this; 
        }
    }

    public static void SoltarCaixa() {

        rbCaixa.gravityScale = Random.Range(2, 4); 
    }

    public static void PousoDaCaixa() {

        ignorarColisao = true; 
    }

    public void UiDesempilhaCaixa() {

        Vector2 newPosition = transform.position; 
        newPosition.y += 2; 
        transform.position = newPosition;
        InstanciaRb();
    }
    

    void OnCollisionEnter2D(Collision2D colisao) {


        if(colisao.gameObject.tag == "Plataforma") {

            audioSource.PlayOneShot(sound, 1f);
            
        } else {

            if(colisao.gameObject.tag == "Caixa") {

                audioSource.PlayOneShot(sound, 1f);
            }
        }
    } 

}

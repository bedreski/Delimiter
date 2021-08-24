using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoSonoro : MonoBehaviour {
    
    private AudioSource audioSource; 
    public AudioClip sound; 


    void Start() {

        audioSource = GetComponent<AudioSource>(); 
    }


    public void BotaoPlayUI() {

        audioSource.PlayOneShot(sound); 
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrParaExpressoes : MonoBehaviour {

    public CanvasGroup background; 
    public Transform quadro; 

    public void Habilitado() {

        background.alpha = 0; 
        background.LeanAlpha(1, 0.5f); 

        quadro.localPosition = new Vector2(0, -Screen.height); 
        quadro.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f; 

        gameObject.SetActive(true);
    }

    public void FecharDialogo() {

        background.LeanAlpha(0, 0.5f); 
        quadro.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(Completo); 

    }

    void Completo() {

        gameObject.SetActive(false); 
    }
}

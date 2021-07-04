using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;


public class FluxoCenas : MonoBehaviour {

    public void IrParaExpressoes() {

        SceneManager.LoadScene("chooseExpression"); 
    }

    public void VoltarParaInicio() {

        SceneManager.LoadScene("startScene"); 
    }

    public void BotaoExp1() {

        SceneManager.LoadScene("expression1");
    }

    public void BotaoExp2() {

        SceneManager.LoadScene("expression2");

    }

    public void BotaoExp3() {

        SceneManager.LoadScene("expression3");
    }

    public void BotaoExp4() {

        SceneManager.LoadScene("expression4");
    }

}

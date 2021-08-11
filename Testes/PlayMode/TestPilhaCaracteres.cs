using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPilhaCaracteres {
    
    [Test]
    public void TestVerificacaoComPilha() { 

        Stack <string> pilha = new Stack <string>(); 
        string e = "a*{b+(c))}", topo = null; 
        bool verificacao = false; 

        for(int i = 0; i < e.Length; i++) {

            if((e[i] == '{' || e[i] == '(' ) || e[i] == '[') {

                pilha.Push(e[i].ToString()); 

            } else {
                
                if((e[i] == '}' || e[i] == ')') || e[i] == ']') {

                    topo = pilha.Pop(); 
                    verificacao = compara(topo, e[i].ToString()); 
                    Assert.True(verificacao); 
                }
            }
        }
    }



    //Auxiliar para teste
    bool compara(string a, string f) {

        if(a == "{" && f == "}") {

            return true;

        } else  {

            if(a == "(" && f == ")") {

                return true; 

            } else {

                if(a == "[" && f == "]") {

                    return true; 

                } 
            }
        } 

        return false; 
    }
}

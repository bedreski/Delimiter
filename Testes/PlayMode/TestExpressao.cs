using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestExpressao {

    [Test]
    public void TestExpressaoNula() {  

        var expressao2 = "a*{b+(c))}"; 

        Assert.Null(expressao2);
    }

    [Test]
    public void TestTamanhoExpressao() {

        var expressao4 = "a+b(c*(d+e))";

        Assert.GreaterOrEqual(expressao4.Length, 12); 
    }
}


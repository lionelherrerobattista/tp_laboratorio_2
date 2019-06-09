using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Entidades_TP3;
using ENacionalidad = EntidadesAbstractas.Persona.ENacionalidad;

namespace Test_TP3
{
    [TestClass]
    public class Text_ValorNumerico
    {
        /// <summary>
        /// Comprueba que un valor numérico se encuentre dentro del rango indicado
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            int dato = 1111111;
            int dniValidado = 0;

            if (dato >= 1 && dato <= 89999999)
            {
                dniValidado = dato;

                Assert.AreEqual(dniValidado, dato);

            }
            else
            {
                Assert.Fail();
            }


        }

    }
    
}


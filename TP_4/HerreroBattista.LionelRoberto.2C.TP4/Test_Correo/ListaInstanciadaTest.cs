using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace Test_Correo
{
    /// <summary>
    /// Verifica que la lista de Paquetes del Correo esté instanciada
    /// </summary>
    [TestClass]
    public class ListaInstanciadaTest
    {
        [TestMethod]
        public void ComprobarListaInstanciada()
        {
            //Arrange
            Correo correoTest;
            
            //Act 
            correoTest = new Correo();
            
            //Assert
            Assert.IsNotNull(correoTest.Paquetes);

        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_Correo
{
    /// <summary>
    /// Verifica que no se puedan cargar dos paquetes con el mismo Tracking ID
    /// </summary>
    [TestClass]
    public class PaquetesTest
    {

        [TestMethod]
        public void ComprobarPaquetesRepetidos()
        {
            //Arrange
            bool lanzoExcepcion = false;

            Correo correoTest;
            Paquete p1;
            Paquete p2;

            //Act
            correoTest = new Correo();
            p1 = new Paquete("Callao 111", "222");
            p2 = new Paquete("Callao 222", "222");


            //Assert
            try
            {
                correoTest += p1;
            }
            catch(TrackingIdRepetidoException e1)
            {
                Assert.Fail();

                throw e1;
            }

            try
            {
                correoTest += p2;
            }
            catch (TrackingIdRepetidoException e2)
            {
                lanzoExcepcion = true;

                Assert.ReferenceEquals(e2, typeof(TrackingIdRepetidoException));
            }

            if(lanzoExcepcion == false)
            {
                Assert.Fail();
            }


        }
    }
}

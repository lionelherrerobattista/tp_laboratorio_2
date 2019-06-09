using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Entidades_TP3;

namespace Test_TP3
{

    [TestClass]
    public class Test_ArchivosException
    {
        /// <summary>
        /// Comprueba que la excepción lanzada sea del tipo ArchivosException
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            
            //arrange
            string archivos = "pruebaException.txt";
            string datos;
            bool capturoException = false;

            Texto archivoTexto = new Texto();

            //act
            
            try
            {
                archivoTexto.Leer(archivos, out datos);
            }
            catch(Exception e)
            {
                capturoException = true;
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }

            if(capturoException == false)
            {
                Assert.Fail();
            }
            
        }
    }
}

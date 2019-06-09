using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades_TP3;

namespace Test_TP3
{
    
    [TestClass]
    public class Test_ValoresNulos
    {
      
        /// <summary>
        /// Comprueba que la clase no se cree con atributos
        /// que contengan valores nulos
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Universidad universidadTest = new Universidad();

            Assert.IsNotNull(universidadTest.Alumnos);
            Assert.IsNotNull(universidadTest.Instructores);
            Assert.IsNotNull(universidadTest.Jornadas);
            
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades_TP3;
using EntidadesAbstractas;

namespace Test_TP3
{
 
    [TestClass]
    public class Test_AlumnoRepetidoException
    {
      
        /// <summary>
        /// Comprueba que al agregar un alumno repetido la excepción lanzada sea
        /// del tipo AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            bool lanzoException = false;

            Universidad universidadTest = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Pérez", "11.111.111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Juan", "Pérez", "11.111.111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            //Act
            try
            {
                universidadTest += a1;
            }
            catch
            {
                Assert.Fail();
            }

            try
            {
                universidadTest += a2;
            }
            catch(Exception e2)
            {
                lanzoException = true;
                Assert.IsInstanceOfType(e2, typeof(AlumnoRepetidoException));
            }


            if(lanzoException == false)
            {
                Assert.Fail();
            }
        }
    }
}

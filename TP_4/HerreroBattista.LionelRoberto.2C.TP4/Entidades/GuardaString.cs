using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MetodoDeExtension
{
    public static class GuardaString
    {
        /// <summary>
        /// Método de Extensión que guarda un texto en un archivo en el escritorio
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Path del archivo</param>
        /// <returns>True si guardó, false si hubo error</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool guardado = true;

            
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);

              
                sw.WriteLine(texto, true);
              

                sw.Close();
            }
            catch
            {
                Exception e = new Exception("No se pudo guardar el archivo de texto.");

                guardado = false;

                throw e;
            }
                
            
            

            return guardado;
        }

        
    }
}

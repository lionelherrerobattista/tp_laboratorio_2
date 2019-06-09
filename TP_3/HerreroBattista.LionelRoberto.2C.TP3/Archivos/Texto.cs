using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades_TP3
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos pasados como parámetro en un archivo .txt
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>true si guardó, false si hubo error</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool guardoArchivo = true;

            StreamWriter writer;

            try
            {
                writer = new StreamWriter(archivo);

                writer.WriteLine(datos);

                writer.Close();

            }
            catch (Exception e)
            {
                guardoArchivo = false;

                throw new ArchivosException(e);
            }



            return guardoArchivo;
        }

        /// <summary>
        /// Lee los datos guardados en un archivo .txt
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos que se encuentran en el archivo</param>
        /// <returns>true si puedo leer, false si hubo error</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool leyoArchivo = true;

            StreamReader reader;

            try
            {
                reader = new StreamReader(archivo);

                datos = reader.ReadToEnd();

                reader.Close();
            }
            catch (Exception e)
            {

                leyoArchivo = false;

                throw new ArchivosException(e);

            }


            return leyoArchivo;
        }
    }
}

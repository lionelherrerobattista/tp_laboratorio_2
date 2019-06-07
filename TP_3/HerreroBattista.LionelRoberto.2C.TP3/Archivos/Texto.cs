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

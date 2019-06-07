using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace Entidades_TP3
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool guardoArchivo = true;

            XmlTextWriter writer;
            XmlSerializer ser;

            

            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);

                ser = new XmlSerializer(typeof(T));

                ser.Serialize(writer, datos);

                writer.Close();

            }
            catch(Exception e)
            {
                guardoArchivo = false;

                throw new ArchivosException(e);
            }
            
            

            return guardoArchivo;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool leyoArchivo = true;


            XmlTextReader reader;
            XmlSerializer ser;

            
            try
            {
                reader = new XmlTextReader(archivo);

                ser = new XmlSerializer(typeof(T));

                datos = (T)ser.Deserialize(reader);

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

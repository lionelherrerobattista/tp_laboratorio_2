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
      bool guardoArchivo = false;

      XmlTextWriter writer;
      XmlSerializer ser;
      
      writer = new XmlTextWriter(archivo, Encoding.UTF8);

      ser = new XmlSerializer(typeof(T));

      ser.Serialize(writer, datos);

      writer.Close();

      if(File.Exists(archivo))
      {
        guardoArchivo = true;
      }

      return guardoArchivo;
    }

    public bool Leer(string archivo, out T datos)
    {
      bool leyoArchivo = false;

      
      XmlTextReader reader;
      XmlSerializer ser;

      reader = new XmlTextReader(archivo);

      try
      {
        

        ser = new XmlSerializer(typeof(T));

        datos = (T)ser.Deserialize(reader);

        leyoArchivo = true;
      }
      catch(Exception e)
      {
        throw new ArchivosException(e);
      }
      finally
      {
        reader.Close();
      }
      return leyoArchivo;
    }
  }
}

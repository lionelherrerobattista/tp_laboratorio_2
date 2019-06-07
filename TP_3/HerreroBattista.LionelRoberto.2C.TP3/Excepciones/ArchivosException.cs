using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
  public class ArchivosException : Exception
  {
    public ArchivosException(Exception innerException)
      :base("Error del archivo", innerException)
    {

    }
  }
}

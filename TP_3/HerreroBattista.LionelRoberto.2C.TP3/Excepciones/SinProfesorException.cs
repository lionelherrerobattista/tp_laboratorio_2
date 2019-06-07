using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
  public class SinProfesorException : Exception
  {
    public SinProfesorException()
      : base ("No hay profesor para la clase.")
    {

    }
  }
}

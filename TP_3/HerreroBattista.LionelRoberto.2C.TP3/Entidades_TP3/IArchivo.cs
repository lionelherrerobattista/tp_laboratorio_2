using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
  public interface IArchivo<T>
  {
    bool Guardar(string archivo, T datos);

    bool Leer(string archivo, out T datos);
  }
}

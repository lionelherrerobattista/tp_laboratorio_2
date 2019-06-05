using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
  public class Universidad
  {
    public enum EClases
    {
      Programacion,
      Laboratorio,
      Legislacion,
      SPD

    }

    private List<Alumno> alumnos;
    private List<Jornada> jornadas;
    private List<Profesor> profesores;

    public Universidad()
    {

    }

    public List<Alumno> Alumnos
    {
      get
      {

      }
      set
      {

      }
    }

    public List<Profesor> Instructores
    {
      get
      {

      }
      set
      {

      }
    }

    public List<Jornada> Jornadas
    {
      get
      {

      }
      set
      {

      }
    }

    public Jornada this[int i]
    {
      get
      {
        Jornada jornadaAux = null;

        if( i < this.jornadas.Count)
        {
          jornadaAux = this.jornadas[i];
        }

        return jornadaAux;
      }
      set
      {
        if (i < this.jornadas.Count)
        {
          this.jornadas[i] = value;
        }
      }
    }

    public bool Guardar(Universidad uni)
    {

    }

    private string MostrarDatos(Universidad uni)
    {

    }

    public override string ToString()
    {
      return base.ToString();
    }

    public static bool operator !=(Universidad g, Alumno a)
    {

    }

    public static bool operator !=(Universidad g, Profesor i)
    {

    }

    public static Profesor operator !=(Universidad g, EClases clase)
    {

    }

    public static Universidad operator +(Universidad g, EClases clase)
    {

    }

    public static Universidad operator +(Universidad g, Alumno a)
    {

    }

    public static Universidad operator +(Universidad g, Profesor i)
    {

    }

    public static bool operator ==(Universidad g, Alumno a)
    {

    }

    public static bool operator ==(Universidad g, Profesor i)
    {

    }

    public static Profesor operator ==(Universidad g, EClases clase)
    {

    }
  }
}

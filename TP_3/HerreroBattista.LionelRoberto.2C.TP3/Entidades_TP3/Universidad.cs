using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        return this.alumnos;
      }
      set
      {
        this.alumnos = value;
      }
    }

    public List<Profesor> Instructores
    {
      get
      {
        return this.profesores;
      }
      set
      {
        this.profesores = value;
      }
    }

    public List<Jornada> Jornadas
    {
      get
      {
        return this.jornadas;
      }
      set
      {
        this.jornadas = value;
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
      string archivo;

      Xml<string> archivoxml = new Xml<string>();

      archivo = String.Format("{0}\\Archivos\\Universidad.xml", Directory.GetCurrentDirectory());

      return archivoxml.Guardar(archivo, uni.ToString());
    }

    private static string MostrarDatos(Universidad uni)
    {
      return uni.ToString();
    }

    public override string ToString()
    {
      string datos;

      datos = "ALUMNOS";

      foreach(Alumno alumno in this.Alumnos)
      {
        datos = String.Format("{0}\n{1}", datos, alumno.ToString());
      }

      datos = String.Format("{0}\n{1}", datos, "JORNADAS");

      foreach(Jornada jornada in this.Jornadas)
      {
        datos = String.Format("{0}\n{1}", datos, jornada.ToString());
      }

      datos = String.Format("{0}\n{1}", datos, "PROFESORES");

      foreach (Profesor profesor in this.Instructores)
      {
        datos = String.Format("{0}\n{1}", datos, this.Instructores);
      }

      return datos;
    }

    public static bool operator !=(Universidad g, Alumno a)
    {
      return !(g == a);
    }

    public static bool operator !=(Universidad g, Profesor i)
    {
      return !(g != i);
    }

    public static Profesor operator !=(Universidad g, EClases clase)
    {
      Profesor auxProfesor = null;

      foreach (Profesor profesor in g.Instructores)
      {
        if (profesor != clase)
        {
          auxProfesor = profesor;
          break;
        }
      }

      return auxProfesor;
    }

    public static Universidad operator +(Universidad g, EClases clase)
    {
      Jornada nuevaJornada = null;
      Profesor profesor;

      profesor = (g == clase);
     
      nuevaJornada = new Jornada(clase, profesor);

      foreach(Alumno alumno in g.Alumnos)
      {
        if(alumno == clase)
        {
          nuevaJornada.Alumnos.Add(alumno);
        }
      }

      g.Jornadas.Add(nuevaJornada);

      return g;
      
    }

    public static Universidad operator +(Universidad g, Alumno a)
    {
      if(g != a)
      {
        g.Alumnos.Add(a);
      }

      return g;
    }

    public static Universidad operator +(Universidad g, Profesor i)
    {
      if(g != i)
      {
        g.Instructores.Add(i);
      }

      return g;
    }

    public static bool operator ==(Universidad g, Alumno a)
    {
      bool sonIguales = false;

      foreach(Alumno auxAlumno in g.Alumnos)
      {
        if(auxAlumno == a)
        {
          sonIguales = true;
        }
      }

      return sonIguales;
    }

    public static bool operator ==(Universidad g, Profesor i)
    {
      bool sonIguales = false;

      foreach(Profesor auxProfesor in g.Instructores)
      {
        if(auxProfesor == i)
        {
          sonIguales = true;
        }
      }

      return sonIguales;
    }

    public static Profesor operator ==(Universidad g, EClases clase)
    {
      Profesor auxProfesor = null;

      foreach (Profesor profesor in g.Instructores)
      {
        if (profesor == clase)
        {
          auxProfesor = profesor;
          break;
        }
      }

      if(auxProfesor == null)
      {
        throw new SinProfesorException();
      }

      return auxProfesor;
    }
  }
}

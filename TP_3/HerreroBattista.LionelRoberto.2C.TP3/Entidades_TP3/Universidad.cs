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
      return !(g == a);
    }

    public static bool operator !=(Universidad g, Profesor i)
    {

    }

    public static Profesor operator !=(Universidad g, EClases clase)
    {

    }

    public static Universidad operator +(Universidad g, EClases clase)
    {
      Jornada nuevaJornada = null;

      foreach(Profesor profesor in g.Instructores)
      {
        if(profesor == clase)
        {
          nuevaJornada = new Jornada(clase, profesor);
        }
      }

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

    }

    public static Universidad operator +(Universidad g, Profesor i)
    {

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

    }
  }
}

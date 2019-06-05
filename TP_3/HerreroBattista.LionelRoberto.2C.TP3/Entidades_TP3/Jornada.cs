using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EClases = Entidades_TP3.Universidad.EClases;

namespace Entidades_TP3
{
  public class Jornada
  {
    private List<Alumno> alumnos;
    private EClases clase;
    private Profesor instructor;

    private Jornada()
    {
      this.alumnos = new List<Alumno>();
    }

    public Jornada(EClases clase, Profesor instructor)
    {
      this.clase = clase;
      this.instructor = instructor;

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

    public EClases Clase
    {
      get
      {
        return this.clase;
      }
      set
      {
        this.clase = value;
      }
    }

    public Profesor Instructor
    {
      get
      {
        return this.instructor;
      }
      set
      {
        this.instructor = value;
      }
    }

    public bool Guardar(Jornada jornada)
    {

    }

    public string Leer()
    {

    }

    public static bool operator !=(Jornada j, Alumno a)
    {
      return !(j == a);
    }

    public static Jornada operator +(Jornada j, Alumno a)
    {
      bool estaAlumno = false;

      foreach (Alumno auxAlumno in j.Alumnos)
      {
        if (auxAlumno == a)
        {
          estaAlumno = true;
          break;
        }
      }

      if (estaAlumno == false)
      {
        j.Alumnos.Add(a);
      }


      return j;
    }

    public static bool operator ==(Jornada j, Alumno a)
    {
      bool sonIguales = false;

      if (a == j.Clase)
      {

        sonIguales = true;
      }

      return sonIguales;
    }

    public override string ToString()
    {
      string datos;


      datos = String.Format("Clase: {0}", this.Clase);
      datos = String.Format("{0}\nProfesor: {1}", datos, this.Instructor);
      datos = String.Format("{0}\nAlumnos:", datos);

      foreach (Alumno alumno in this.Alumnos)
      {
        datos = String.Format("{0}\n{1}", datos, alumno.ToString());
      }

      return base.ToString();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EClases = Entidades_TP3.Universidad.EClases;


namespace Entidades_TP3
{
  public sealed class Alumno : Universitario
  {
    public enum EEstadoCuenta
    {
      AlDia,
      Deudor,
      Becado
    }

    private EClases claseQueToma;
    private EEstadoCuenta estadoCuenta;

    public Alumno()
    {

    }

    public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
      : base(id, nombre, apellido, dni, nacionalidad)
    {
      this.claseQueToma = claseQueToma;
    }

    public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
      : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
    {
      this.estadoCuenta = estadoCuenta;
    }

    protected override string MostrarDatos()
    {
      string datos;

      datos = String.Format("{0}\n{1}", base.MostrarDatos(), this.ToString());

      return datos;
    }

    public static bool operator !=(Alumno a, EClases clase)
    {
      bool sonDistintos = false;

      if (a.claseQueToma != clase)
      {
        sonDistintos = true;
      }

      return sonDistintos;
    }

    public static bool operator ==(Alumno a, EClases clase)
    {
      bool sonIguales = false;

      if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
      {
        sonIguales = true;
      }

      return sonIguales;
    }

    protected override string ParticiparEnClase()
    {
      string clase;

      clase = String.Format("TOMA CLASE DE {0}", this.claseQueToma);

      return clase;
    }

    public override string ToString()
    {
      string datos;

      datos = String.Format("{0}\nEstado de cuenta: {1}", this.ParticiparEnClase(),
          this.estadoCuenta);

      return datos;
    }
  }
}

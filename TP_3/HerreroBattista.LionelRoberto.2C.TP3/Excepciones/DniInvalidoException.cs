﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
            : base("DNI Inválido.")
        {

        }

        public DniInvalidoException(Exception e)
            : base("DNI Inválido.", e)
        {

        }

        public DniInvalidoException(string message)
            : base(message)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {

        }
    }
}

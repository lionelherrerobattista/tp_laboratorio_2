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
            : base()
        {

        }

        public DniInvalidoException(Exception e)
            : base("", e)
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

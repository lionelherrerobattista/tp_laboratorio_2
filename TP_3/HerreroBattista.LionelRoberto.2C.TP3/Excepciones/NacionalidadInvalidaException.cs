﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
            : base()
        {

        }

        public NacionalidadInvalidaException(string message)
            : base(message)
        {

        }
    }
}

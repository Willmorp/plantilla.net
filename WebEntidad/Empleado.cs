using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEntidad
{
    public class Empleado
    {
        public int codigo{get;set;}
        public string nombre{get;set;}
        public double horas{get;set;}
        public double tarifa{get;set;}

        public double pago {
            get { return horas * tarifa; }
        }
        
    }
}
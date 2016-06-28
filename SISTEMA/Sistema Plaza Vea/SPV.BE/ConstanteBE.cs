using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    [Serializable]
    public class ConstanteBE
    {
        public const string OBJECTO_TODOS = "--Todos--";
        public const string OBJECTO_SELECCIONE = "--Seleccione--";
        public const string OBJECTO_TIPO_TODOS = "A";
        public const string OBJECTO_TIPO_SELECCIONE = "B";

        /*KEYS PARA AGREGAR Y MODIFICAR*/
        public const string TIPO_AGREGAR = "Agregar";
        public const string TIPO_MODIFICAR = "Modificar";

    }
}
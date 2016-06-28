using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPV.BE
{
    public enum direccionOrden
    {
        Ascending,
        Descending
    }

    public enum flagsIncoterm
    {
        basico = 0,
        recColorExt,
        recColorInt,
        extras,
        fob,
        flete,
        seguro
    }

    public enum TipoAdjunto
    {
        todos = 0,
        imagenMEI,
        imagenSpecCode,
        informatico,
        soloDOC,
        soloDOCyPDF
    }
}
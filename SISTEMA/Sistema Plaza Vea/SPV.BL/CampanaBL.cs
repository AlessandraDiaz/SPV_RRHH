﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPV.DA;
using SPV.BE;

namespace SPV.BL
{
    public class CampanaBL
    {
        public List<CampanaBE> ListarCampana(CampanaBE campana)
        {
            return new CampanaDA().ListarCampana(campana).ToList();
        }
    }
}
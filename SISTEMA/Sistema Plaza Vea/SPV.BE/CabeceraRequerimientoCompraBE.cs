using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SPV.BE
{
    [Serializable]
    public class CabeceraRequerimientoCompraBE
    {
        #region "Atributos"
        private Int32 _id_cabecera_requerimiento_compra;
        private Int32 _id_solicitante;
        private String _de_solicitante;
        private Int32 _id_estado;
        private String _de_estado;
        private String _fe_creacion;
        private Int32 _id_usuario_creacion;
        private String _de_usuario_creacion;
        private String _fe_cambio;
        private Int32 _id_usuario_cambio;
        private String _de_usuario_cambio;
        private String _fe_en_proceso;
        private String _fe_espera_justificacion;
        private String _fe_anulado;
        private String _fe_espera_cotizacion;
        private String _fe_cotizado;
        private String _fe_espera_solicitante;
        private String _fe_pendiente_aprobacion;
        private String _fe_rechazado;
        private String _fe_aprobado;
        private String _de_observacion;
        #endregion

        #region "Propiedades"
        public Int32 id_cabecera_requerimiento_compra
        {
            get { return _id_cabecera_requerimiento_compra; }
            set { _id_cabecera_requerimiento_compra = value; }
        }

        public Int32 id_solicitante
        {
            get { return _id_solicitante; }
            set { _id_solicitante = value; }
        }

        public String de_solicitante
        {
            get { return _de_solicitante; }
            set { _de_solicitante = value; }
        }

        public Int32 id_estado
        {
            get { return _id_estado; }
            set { _id_estado = value; }
        }

        public String de_estado
        {
            get { return _de_estado; }
            set { _de_estado = value; }
        }

        public String fe_creacion
        {
            get { return _fe_creacion; }
            set { _fe_creacion = value; }
        }

        public Int32 id_usuario_creacion
        {
            get { return _id_usuario_creacion; }
            set { _id_usuario_creacion = value; }
        }

        public String de_usuario_creacion
        {
            get { return _de_usuario_creacion; }
            set { _de_usuario_creacion = value; }
        }

        public String fe_cambio
        {
            get { return _fe_cambio; }
            set { _fe_cambio = value; }
        }

        public Int32 id_usuario_cambio
        {
            get { return _id_usuario_cambio; }
            set { _id_usuario_cambio = value; }
        }

        public String de_usuario_cambio
        {
            get { return _de_usuario_cambio; }
            set { _de_usuario_cambio = value; }
        }

        public String fe_en_proceso
        {
            get { return _fe_en_proceso; }
            set { _fe_en_proceso = value; }
        }

        public String fe_espera_justificacion
        {
            get { return _fe_espera_justificacion; }
            set { _fe_espera_justificacion = value; }
        }

        public String fe_anulado
        {
            get { return _fe_anulado; }
            set { _fe_anulado = value; }
        }

        public String fe_espera_cotizacion
        {
            get { return _fe_espera_cotizacion; }
            set { _fe_espera_cotizacion = value; }
        }

        public String fe_cotizado
        {
            get { return _fe_cotizado; }
            set { _fe_cotizado = value; }
        }

        public String fe_espera_solicitante
        {
            get { return _fe_espera_solicitante; }
            set { _fe_espera_solicitante = value; }
        }

        public String fe_pendiente_aprobacion
        {
            get { return _fe_pendiente_aprobacion; }
            set { _fe_pendiente_aprobacion = value; }
        }

        public String fe_rechazado
        {
            get { return _fe_rechazado; }
            set { _fe_rechazado = value; }
        }

        public String fe_aprobado
        {
            get { return _fe_aprobado; }
            set { _fe_aprobado = value; }
        }

        public String de_observacion
        {
            get { return _de_observacion; }
            set { _de_observacion = value; }
        }        
        #endregion
    }

    #region "Lista"
    [Serializable]
    public class CabeceraOrdenCompraBEList : List<CabeceraRequerimientoCompraBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            CabeceraOrdenCompraComparer dc = new CabeceraOrdenCompraComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class CabeceraOrdenCompraComparer : IComparer<CabeceraRequerimientoCompraBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public CabeceraOrdenCompraComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(CabeceraRequerimientoCompraBE x, CabeceraRequerimientoCompraBE y)
        {
            /*if (!(x.GetType().ToString() == y.GetType().ToString()))
            {
                throw new ArgumentException("Objects must be of the same type");
            }*/

            PropertyInfo propertyX = x.GetType().GetProperty(_prop);
            PropertyInfo propertyY = y.GetType().GetProperty(_prop);

            object px = propertyX.GetValue(x, null);
            object py = propertyY.GetValue(y, null);

            if (px == null && py == null)
            {
                return 0;
            }
            else if (px != null && py == null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (px == null && py != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (px.GetType().GetInterface("IComparable") != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return ((IComparable)px).CompareTo(py);
                }
                else
                {
                    return ((IComparable)py).CompareTo(px);
                }
            }
            else
            {
                return 0;
            }
        }
    }
    #endregion
}
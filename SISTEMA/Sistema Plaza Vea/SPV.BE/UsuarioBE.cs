using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace SPV.BE
{
    [Serializable]
    public class UsuarioBE
    {
        #region "Atributos"
        private Int32 _id_usuario;
        private String _no_login;
        private String _no_password;
        private String _no_usuario;
        private String _no_apellido_paterno;
        private String _no_apellido_materno;
        private String _fl_inactivo;
        private String _CUSR_ID;
        private Int32 _id_rol;
        private String _rol;
        private String _estado;
        private Int32 _co_usuario_crea;
        private String _fe_crea;
        private Int32 _co_usuario_cambio;
        private String _fe_cambio;
        private String _de_observacion;

        private Int32 _id_area;
        private String _no_area;
        private Int32 _id_empresa;
        private String _no_empresa;
        private String _fl_usuario;
        #endregion

        #region "Propiedades"
        public Int32 id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        public String no_login
        {
            get { return _no_login; }
            set { _no_login = value; }
        }

        public String no_password
        {
            get { return _no_password; }
            set { _no_password = value; }
        }

        public String no_usuario
        {
            get { return _no_usuario; }
            set { _no_usuario = value; }
        }

        public String no_apellido_paterno
        {
            get { return _no_apellido_paterno; }
            set { _no_apellido_paterno = value; }
        }

        public String no_apellido_materno
        {
            get { return _no_apellido_materno; }
            set { _no_apellido_materno = value; }
        }

        public String fl_inactivo
        {
            get { return _fl_inactivo; }
            set { _fl_inactivo = value; }
        }

        public String CUSR_ID
        {
            get { return this._CUSR_ID; }
            set { this._CUSR_ID = value; }
        }

        public String rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public Int32 id_rol
        {
            get { return _id_rol; }
            set { _id_rol = value; }
        }

        public String estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Int32 co_usuario_crea
        {
            get { return _co_usuario_crea; }
            set { _co_usuario_crea = value; }
        }

        public String fe_crea
        {
            get { return _fe_crea; }
            set { _fe_crea = value; }
        }

        public Int32 co_usuario_cambio
        {
            get { return _co_usuario_cambio; }
            set { _co_usuario_cambio = value; }
        }

        public String fe_cambio
        {
            get { return _fe_cambio; }
            set { _fe_cambio = value; }
        }

        public String de_observacion
        {
            get { return _de_observacion; }
            set { _de_observacion = value; }
        }

        public String no_area
        {
            get { return _no_area; }
            set { _no_area = value; }
        }

        public Int32 id_area
        {
            get { return _id_area; }
            set { _id_area = value; }
        }

        public String no_empresa
        {
            get { return _no_empresa; }
            set { _no_empresa = value; }
        }

        public Int32 id_empresa
        {
            get { return _id_empresa; }
            set { _id_empresa = value; }
        }

        public String fl_usuario
        {
            get { return _fl_usuario; }
            set { _fl_usuario = value; }
        }
        #endregion

        #region "PropiedadeMySql"

        [Display(Name = "ID")]
        [Key]
        public int CodigoUsuario { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Area")]
        public AreaTiendaBE Area { get; set; }
        [Display(Name = "Perfil")]
        public PerfilBE Perfil { get; set; }
        [Display(Name = "Local")]
        public TiendaBE Local { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }
        [Display(Name = "Estado")]
        public int EstadoUsuario { get; set; }
        #endregion

    }

    #region "Lista"
    [Serializable]
    public class UsuarioBEList : List<UsuarioBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            UsuarioComparer dc = new UsuarioComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class UsuarioComparer : IComparer<UsuarioBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public UsuarioComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(UsuarioBE x, UsuarioBE y)
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
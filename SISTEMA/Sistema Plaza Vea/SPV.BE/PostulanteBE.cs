using System;

namespace SPV.BE
{
    public class PostulanteBE
    {
        //Patron Composite
        #region "Atributos"
        private String apellidoPaterno;
        private String apellidoMaterno;
        private String nombres;
        private String dni;
        private String turno;
        private DateTime fechaNacimiento;
        private String sexo;
        private String direccion;
        private String telefono;
        private String correo;
       #endregion

        #region "Propiedades"
        public String ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        public String ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }

        public String Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        public String Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        public String Turno
        {
            get { return turno; }
            set { turno = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public String Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        #endregion

        #region "Constructor"
        public PostulanteBE(String p_ApellidoPaterno, String p_ApellidoMaterno, String p_Nombres, String p_Dni, DateTime p_FechaNacimiento, String p_Sexo, String p_Direccion, String p_Telefono, String p_Correo) {
            this.apellidoPaterno = p_ApellidoPaterno;
            this.apellidoMaterno = p_ApellidoMaterno;
            this.nombres = p_Nombres;
            this.dni = p_Dni;
            this.fechaNacimiento = p_FechaNacimiento;
            this.sexo = p_Sexo;
            this.direccion = p_Direccion;
            this.telefono = p_Telefono;
            this.correo = p_Correo;
        }
        #endregion
    }
}

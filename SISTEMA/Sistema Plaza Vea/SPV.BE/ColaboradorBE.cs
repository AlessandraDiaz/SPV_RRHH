using System;

namespace SPV.BE
{
    public class ColaboradorBE
    {
        //Patron Composite
        #region "Atributos"
        private String apellidoPaterno;
        private String apellidoMaterno;
        private String nombres;
        private String dni;
        private DateTime fechaNacimiento;
        private DateTime fechaAperturaFicha;
        private String sexo;
        private String direccion;
        private String telefono;
        private String correoPersonal;
        private String correoInstitucional;
        private String nroHijoMenores;
        private String estadoCivil;
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
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public DateTime FechaAperturaFicha
        {
            get { return fechaAperturaFicha; }
            set { fechaAperturaFicha = value; }
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
        public String CorreoPersonal
        {
            get { return correoPersonal; }
            set { correoPersonal = value; }
        }
        public String CorreoInstitucional
        {
            get { return correoInstitucional; }
            set { correoInstitucional = value; }
        }
        public String NroHijoMenores
        {
            get { return nroHijoMenores; }
            set { nroHijoMenores = value; }
        }
        public String EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }
        #endregion

        #region "Constructor"
        public ColaboradorBE(String p_ApellidoPaterno, String p_ApellidoMaterno, String p_Nombres, String p_Dni, DateTime p_FechaNacimiento, DateTime p_FechaAperturaFicha, String p_Sexo, String p_Direccion, String p_Telefono, String p_CorreoPersonal, String p_CorreoInstitucional, String p_NroHijosMenores, String p_EstadoCivil) {
            this.apellidoPaterno = p_ApellidoPaterno;
            this.apellidoMaterno = p_ApellidoMaterno;
            this.nombres = p_Nombres;
            this.dni = p_Dni;
            this.fechaNacimiento = p_FechaNacimiento;
            this.fechaAperturaFicha = p_FechaAperturaFicha;
            this.sexo = p_Sexo;
            this.direccion = p_Direccion;
            this.telefono = p_Telefono;
            this.correoPersonal = p_CorreoPersonal;
            this.correoInstitucional = p_CorreoInstitucional;
            this.nroHijoMenores = p_NroHijosMenores;
            this.estadoCivil = p_EstadoCivil;
        }
        #endregion
        
    }
}

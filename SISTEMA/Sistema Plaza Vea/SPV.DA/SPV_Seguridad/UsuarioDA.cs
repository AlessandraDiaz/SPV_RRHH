using System;
using System.Collections.Generic;
using System.Text;
using SPV.BE;
using System.Data;
using MySql.Data;

namespace SPV.DA.SPV_Seguridad
{
    public class UsuarioDA
    {
        public UsuarioBE ValidaLogeoUsuario(String usuario, String pass)
        {
            UsuarioBE oUsuario = null;
            int Indice;
            IDataReader reader = null;
            try
            {
                using (Database db = new Database())
                {
                    db.ProcedureName = "[general].[spv_sps_login]";
                    db.AddParameter("@va_no_login", DbType.String, ParameterDirection.Input, usuario);
                    db.AddParameter("@va_no_password", DbType.String, ParameterDirection.Input, pass);
                    reader = db.GetDataReader();
                }

                if (reader.Read())
                {
                    oUsuario = new UsuarioBE();

                    Indice = reader.GetOrdinal("id_usuario");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_usuario = reader.GetInt32(Indice); }

                    Indice = reader.GetOrdinal("no_login");
                    oUsuario.no_login = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_password");
                    oUsuario.no_password = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_usuario");
                    oUsuario.no_usuario = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_apellido_paterno");
                    oUsuario.no_apellido_paterno = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("no_apellido_materno");
                    oUsuario.no_apellido_materno = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("fl_inactivo");
                    oUsuario.fl_inactivo = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("id_rol");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_rol = reader.GetInt32(Indice); }

                    Indice = reader.GetOrdinal("rol");
                    oUsuario.rol = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);

                    Indice = reader.GetOrdinal("id_area");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_area = reader.GetInt32(Indice); }

                   /* Indice = reader.GetOrdinal("no_area");
                    oUsuario.no_area = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);*/

                    Indice = reader.GetOrdinal("id_empresa");
                    if (!reader.IsDBNull(Indice)) { oUsuario.id_empresa = reader.GetInt32(Indice); }

                    /*Indice = reader.GetOrdinal("no_empresa");
                    oUsuario.no_empresa = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);*/

                    Indice = reader.GetOrdinal("fl_usuario");
                    oUsuario.fl_usuario = reader.IsDBNull(Indice) ? String.Empty : reader.GetString(Indice);
                }
                reader.Close();
            }
            catch
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            return oUsuario;
        }        
    }
}
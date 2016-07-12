using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using SPV.BE;

namespace SPV.DA
{
    public class UsuarioGRH_DA
    {
        private String qSQL;

        public UsuarioBE Login(String p_Usuario, String p_Password)
        {
            DataBaseDA dbRRHH = new DataBaseDA();
            UsuarioBE usuarioLogeado = null;
            try
            {
                qSQL = "SP_LOGIN";
                using (MySqlCommand cmd = new MySqlCommand(qSQL, dbRRHH.getConnectionMysql()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", p_Usuario);
                    cmd.Parameters.AddWithValue("@pass", p_Password);
                    cmd.Connection.Open();
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        usuarioLogeado = new UsuarioBE();
                        usuarioLogeado.CodigoUsuario = (Int32)rd[0];
                        usuarioLogeado.NombreUsuario = rd[1].ToString();

                        PerfilBE perfil = new PerfilBE();
                        perfil.CodPerfil = (Int32)rd[2];
                        perfil.Perfil = rd[3].ToString();

                        ExamenBE examen = new ExamenBE();
                        examen.ID = (Int32)rd[8];
                        perfil.Examen = examen;

                        usuarioLogeado.Perfil = perfil;

                        AreaTiendaBE area = new AreaTiendaBE();
                        area.CodArea = (Int32)rd[4];
                        area.Descripcion = rd[5].ToString();
                        usuarioLogeado.Area = area;

                        TiendaBE tienda = new TiendaBE();
                        tienda.CodTienda = (Int32)rd[6];
                        tienda.NombreTienda = rd[7].ToString();
                        usuarioLogeado.Local = tienda;

                        usuarioLogeado.RindioExamen = (Int32)rd[8];
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                dbRRHH = null;
            }

            return usuarioLogeado;
        }

    }
}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using SPV.BE;

public class Global
{
	public Global()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region "Metodos"
    public static String GetTamanioArchivo(Int32 tamanio)
    {
        String retorno = String.Empty;
        int nivel = 0;
        Double tamanioD;
        Int32 division;
        Int32 mod;

        if (tamanio > 0)
        {
            division = tamanio / 1024;
            mod = tamanio % 1024;

            if (division > 0)
            {
                nivel++;
                while (division > 1024)
                {
                    mod = division % 1024;
                    division = division / 1024;
                    nivel++;
                }
                tamanioD = division + ((Double)mod / 1024);
                retorno = String.Format("{0}{1}", tamanioD.ToString("N"), GetSimboloTamanio(nivel));
            }
            else
            {
                retorno = tamanio.ToString() + GetSimboloTamanio(nivel);
            }
        }
        else
        {
            retorno = "0" + GetSimboloTamanio(nivel);
        }
        return retorno;
    }

    private static string GetSimboloTamanio(int nivel)
    {
        String retorno = String.Empty;
        switch (nivel)
        {
            case 0: retorno = "Bytes"; break;
            case 1: retorno = "KB"; break;
            case 2: retorno = "MB"; break;
            default: retorno = "GB"; break;
        }
        return retorno;
    }

    public static void CargarArchivo(String rutaFisica, Byte[] myData, Int32 myDataLength, String nombreArchivo, String extension)
    {
        String RutaPathImageTemp;
        FileStream fs;
        RutaPathImageTemp = rutaFisica /*+ ConstanteBE.RUTA_IMAGEN */+ nombreArchivo + extension;
        fs = new FileStream(@RutaPathImageTemp, FileMode.OpenOrCreate);
        fs.Write(myData, 0, myDataLength);
        fs.Close();
    }

    public static void BorrarArchivo(String rutaFisica, String nombreArchivo, String extension)
    {
        String RutaPathImageTemp;
        FileStream fs;
        RutaPathImageTemp = rutaFisica + /*ConstanteBE.RUTA_IMAGEN +*/ nombreArchivo + extension;
    }
    #endregion

    #region "Manejo de errores no controlados por aplicativo"
    public static System.Exception LastError;

    public static string getMensajeError()
    {
        while (LastError.InnerException != null)
        {
            LastError = LastError.InnerException;
        }
        return LastError.Message;
    }
    #endregion
}
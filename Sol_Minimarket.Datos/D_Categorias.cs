using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Sol_Minimarket.Entidades;

namespace Sol_Minimarket.Datos
{
    public class D_Categorias
    {
        public DataTable Listado_ca (string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SQLcon = new SqlConnection();

            try
            {
                SQLcon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando= new SqlCommand("USP_Listado_ca", SQLcon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SQLcon.Open();
                Resultado=Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(SQLcon.State==ConnectionState.Open) SQLcon.Close();
            }
        }
        public string Guardar_ca (int nOpcion, E_Categorias oCa)
        {
            string Rpta = "";
            SqlConnection sqlCon=new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("UPS_Guardar_ca", sqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion", SqlDbType.Int).Value= nOpcion;
                Comando.Parameters.Add("@nCodigo_ca", SqlDbType.Int).Value = oCa.Codigo_ca;
                Comando.Parameters.Add("@nDescipcion_ca", SqlDbType.VarChar).Value=oCa.Descripcion_ca;
                sqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar los datos";
            }
            catch (Exception ex)
            {
                Rpta=ex.Message;
            }
            finally
            {
                if(sqlCon.State==ConnectionState.Open) sqlCon.Close();
            }
            return Rpta;
        }
    }
}

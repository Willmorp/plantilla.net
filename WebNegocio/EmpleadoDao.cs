using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; // tablas en memoria
using System.Data.SqlClient; // para trabajar con sql Server
using WebEntidad;

namespace WebNegocio
{
    public class EmpleadoDao
    {
        string cadconex = "server=(local); database=empresa; uid=sa; pwd=alumno";
        public int addEmployed(Empleado p)
        {
            int res = 0;
            SqlConnection cn = new SqlConnection(cadconex);
            string sql= "insert into empleado values(@nom,@hr,@tar)";
            //prepara un comando para ejecutar istruccionbes sql
            SqlCommand cmd = new SqlCommand(sql , cn);
            //relacionar cada variable @var con la variable receptora
            cmd.Parameters.AddWithValue("@nom",p.nombre);
            cmd.Parameters.AddWithValue("@hr", p.horas);
            cmd.Parameters.AddWithValue("@tar", p.tarifa);
            cn.Open();
            res = cmd.ExecuteNonQuery();//rerotna entero 1 = ok si no 0 es error
            cn.Close();
            return res;
        }
        
        //obtener la tabla de datos
        public DataTable ListadoCli()
        {
            string sql = "select * from Empleado";
            //preparar un adapatador para ejecutar la instriccion ne conexion cerradad
            SqlDataAdapter da = new SqlDataAdapter(sql, cadconex);
            //ejecucion debe llevarse en una tabla
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public Empleado consulta(int code)
        {
            SqlConnection cn = new SqlConnection(cadconex);
            Empleado ep = null;

            string sql = "select * from empleado where code=@code" ;
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@code",code);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();// es mas optimo
            if (dr.Read()) // si llee la fila existe el dato
            {
                ep = new Empleado();
                ep.nombre = dr.GetString(0);
                ep.horas = dr.GetDouble(1);
                ep.tarifa = dr.GetDouble(2);
            }
            cn.Close();
            return ep;
        }
        


    }
}
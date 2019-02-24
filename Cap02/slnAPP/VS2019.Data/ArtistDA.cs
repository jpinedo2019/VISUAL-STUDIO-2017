using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VS2019.Entities;

namespace VS2019.Data
{
    public class ArtistDA:BaseConnectios
    {
        private SqlDbType nombre;

        public int GetCount()
        {
            var result = 0;
            var sql = "SELECT COUNT(1) FROM Artist";

            // 1. Crear el objeto Connection

            /*IDbConnection cn = new SqlConnection(GetConnection());
            // abrir conexion
            cn.Open();

                    *aquí seguiría el paso 2...*

            cn.Close();*/

            // Al finalizar debo cerrar la conexión, a continuación otra forma de cerrar la conexión de manera automática


            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                // abrir conexion
                cn.Open();

                //2. Crearndo una instancia del objeto command

                IDbCommand cmd = new SqlCommand(sql);

                cmd.Connection = cn;
                //Ejecutando el comando
                result = (int)cmd.ExecuteScalar();

            }
            

            return result;
        }


        /*
         1. List
         1.1. IEnumerable : For, Foreach
         1.2. ICollection: Add, Remove
             
             */
        //IEnumerable: Permite usar For Foreach se usa para traer tablas de la BD

        public IEnumerable<Artist> Gets()
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId, Name FROM Artist";

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                // abrir conexion
                cn.Open();

                //2. Crearndo una instancia del objeto command

                IDbCommand cmd = new SqlCommand(sql);

                cmd.Connection = cn;
                //Ejecutando el comando
                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }

            }

            return result;

        }




        public IEnumerable<Artist> GetsWithParam(string nombre)
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId, Name FROM Artist WHERE Name LIKE @FiltroPorNombre";

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                // abrir conexion
                cn.Open();

                //2. Crearndo una instancia del objeto command

                IDbCommand cmd = new SqlCommand(sql);
                //Configurando los parametros de la consulta sql para evitar sql injection
                cmd.Parameters.Add(new SqlParameter("@FiltroPorNombre", nombre));
                cmd.Connection = cn;
                //Ejecutando el comando
                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }

            }

            return result;

        }





        public IEnumerable<Artist> GetsWithParamSP(string nombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtists";

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                // abrir conexion
                cn.Open();

                //2. Crearndo una instancia del objeto command

                IDbCommand cmd = new SqlCommand(sql);
                //Configurando los parametros de la consulta sql para evitar sql injection
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                cmd.Connection = cn;
                //Ejecutando el comando
                var reader = cmd.ExecuteReader();
                var indice = 0;

                while (reader.Read())
                {
                    var entity = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    entity.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    entity.Name = reader.GetString(indice);

                    result.Add(entity);
                }

            }

            return result;

        }

        //Artist entity: Cuando la consulta tiene mas de un filtro ejm. fechaIni, FechaFin....

        public int InsertArtist(Artist entity)
        {
            var result = 0;
            var sql = "usp_InsertArtist";

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                // abrir conexion
                cn.Open();

                //2. Crearndo una instancia del objeto command

                IDbCommand cmd = new SqlCommand(sql);
                //Configurando los parametros de la consulta sql para evitar sql injection
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.Add(new SqlParameter("@Nombre", entity.Name));

                //Ejecutando el comando
                result = Convert.ToInt32(cmd.ExecuteScalar());
                

                

            }

            return result;

        }



    }
}

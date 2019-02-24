using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS2019.Data
{
    public class BaseConnectios
    {

        public string GetConnection() {

            string cadenaConexion = "Server=S000-00;DataBase=VS2019;User ID=sa;Password=sql;";
            
            return cadenaConexion;


        }

    }
}

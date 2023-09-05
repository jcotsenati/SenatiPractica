using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Connection
    {
        // Connection's configuration:
        private static Connection singleton;
        private SqlConnection sqlConnection;

        public SqlConnection SqlConnetionFactory
        {
            get { return sqlConnection; }
        }

        public string ConnetionString{
            
            set {
                sqlConnection = new SqlConnection(value);
                
            }
        }

        private Connection() { }

        public static Connection Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new Connection();

                return singleton;
            }
        }

    }
}

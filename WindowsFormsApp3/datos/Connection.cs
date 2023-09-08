using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    class Connection
    {
        // Connection's configuration:
        private static Connection singleton;
        private SqlConnection sqlConnection;
        private string connectionString;

        public SqlConnection SqlConnetionFactory
        {
            get {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                return sqlConnection; 
            }
        }

        public string ConnetionString
        {

            set
            {
                if (connectionString != value)
                {
                    connectionString = value;
                    sqlConnection = new SqlConnection(value);
                }

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

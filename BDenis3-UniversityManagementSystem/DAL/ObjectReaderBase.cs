using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BDenis3_UniversityManagementSystem
{
    abstract class ObjectReaderBase<T>
    {
        private static string connString = @"server=localhost;user id = root; password=W3mdDog#01;persistsecurityinfo=True;database=ums";
        protected MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
        protected abstract string SqlCommand { get; }
        protected abstract CommandType SqlCommandType { get; }
        protected abstract Collection<MySqlParameter> GetParameters(MySqlCommand MySqlCommand);
        protected abstract MapperBase<T> GetMapper();

        public Collection<T> Execute()
        {
            Collection<T> coll = new Collection<T>();

            using (MySqlConnection conn = GetConnection())
            {
                MySqlCommand command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = this.SqlCommand;
                command.CommandType = this.SqlCommandType;

                foreach (MySqlParameter p in this.GetParameters(command))
                {
                    command.Parameters.Add(p);
                }

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    using (MySqlDataReader dataReader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapr = GetMapper();
                            coll = mapr.MapAll(dataReader);
                        }
                        catch
                        {

                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
            }

            // Theoretically, this should always have something in it.
            return coll;
        }
    }
}

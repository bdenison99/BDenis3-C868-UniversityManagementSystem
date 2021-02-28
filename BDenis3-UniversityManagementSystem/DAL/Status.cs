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
    class Status
    {
        // private variables for each instance
        private int _status_id;
        private string _status_name;
        private string _user_id;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int StatusID { get => _status_id; set => _status_id = value; }
        public string StatusName { get => _status_name; set => _status_name = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class StatusMapper : MapperBase<Status>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override Status Map(IDataRecord record)
        {
            Status s = new Status();

            try
            {
                s.StatusID = (DBNull.Value == record["status_id"]) ? 0 : (int)record["status_id"];
                s.StatusName = (DBNull.Value == record["name"]) ? string.Empty : (string)record["name"];
                s.IsActive = (DBNull.Value == record["is_active"]) ? false : (bool)record["is_active"];
            }
            catch
            {

            }
            return s;

        }
    }

    class StatusReader : ObjectReaderBase<Status>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.status;"; }
        }

        protected override CommandType SqlCommandType
        {
            get { return System.Data.CommandType.Text; }
        }

        protected override Collection<MySqlParameter> GetParameters(MySqlCommand command)
        {
            Collection<MySqlParameter> parameters = new Collection<MySqlParameter>();
            return parameters;
        }

        protected override MapperBase<Status> GetMapper()
        {
            MapperBase<Status> mapr = new StatusMapper();
            return mapr;
        }
    }
}

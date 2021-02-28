using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDenis3_UniversityManagementSystem
{
    public class UserRole
    {
        // private variables for each instance
        private int _userroleid;
        private string _role_name;
        private bool _isactive;

        // Property declarations for the private variables that can be modified by the application
        public int RoleID { get => _userroleid; set => _userroleid = value; }
        public string RoleName { get => _role_name; set => _role_name = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }
        class UserRoleMapper : MapperBase<UserRole>
        {
            /*
             * This is the User Role Mapper Class which maps a database record to a User Role class object instance
             */
            protected override UserRole Map(IDataRecord record)
            {
                UserRole role = new UserRole();
                try
                {
                    role.RoleID = (DBNull.Value == record["user_role_id"]) ? 0 : (int)record["user_role_id"];
                    role.RoleName = (DBNull.Value == record["role_name"]) ? string.Empty : (string)record["role_name"];
                    role.IsActive = (DBNull.Value == record["is_active"]) ? false : (bool)record["is_active"];
                }
                catch
                {

                }
                return role;

            }
        }

        class UserRoleReader : ObjectReaderBase<UserRole>
        {
            /*
             * This UserReader class is used to execute the SELECT statement in the database and map the rows
             * into a collection of users
             */
            protected override string SqlCommand
            {
                get { return "SELECT * FROM ums.user_roles;"; }
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

            protected override MapperBase<UserRole> GetMapper()
            {
                MapperBase<UserRole> mapr = new UserRoleMapper();
                return mapr;
            }
        }
}

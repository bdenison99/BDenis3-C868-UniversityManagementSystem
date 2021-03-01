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
    public class User
    {
        /*
         * This is the User class object which represents a row in the User table.
         * It is split into private variables which represent each column that the application can modify
         * and object properties for setters and getters to function
         * */
        
        
        // private variables for each instance
        private string _userid;
        private string _preferred_name;
        private string _legal_name;
        private string _password;
        private int _roleid;
        private string _street_address_1;
        private string _street_address_2;
        private string _city;
        private string _state;
        private string _postal_code;
        private string _mobile_phone;
        private string _home_phone;
        private string _work_phone;
        private string _home_email;
        private string _school_email;
        private bool _isactive;

        // Property declarations for the private variables that can be modified by the application
        public string UserID { get => _userid; set => _userid = value; }
        public string PreferredName { get => _preferred_name; set => _preferred_name = value; }
        public string LegalName { get => _legal_name; set => _legal_name = value; }
        public int RoleId { get => _roleid; set => _roleid = value; }
        public string StreetAddress { get => _street_address_1; set => _street_address_1 = value; }
        public string StreetAddress2 { get => _street_address_2; set => _street_address_2 = value; }
        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string PostalCode { get => _postal_code; set => _postal_code = value; }
        public string MobilePhone { get => _mobile_phone; set => _mobile_phone = value; }
        public string HomePhone { get => _home_phone; set => _home_phone = value; }
        public string WorkPhone { get => _work_phone; set => _work_phone = value; }
        public string HomeEmail { get => _home_email; set => _home_email = value; }
        public string SchoolEmail { get => _school_email; set => _school_email = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
        public string Password { get => _password; set => _password = value; }
    }

    class UserMapper: MapperBase<User>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override User Map(IDataRecord record)
        {
            User u = new User();
            try
            {
                u.UserID = (DBNull.Value == record["user_id"]) ? string.Empty : (string)record["user_id"];
                u.Password = (DBNull.Value == record["password"]) ? string.Empty : (string)record["password"];
                u.RoleId = (DBNull.Value == record["user_role_id"]) ? 0 : (int)record["user_role_id"];
                u.LegalName = (DBNull.Value == record["legal_name"]) ? string.Empty : (string)record["legal_name"];
                u.PreferredName = (DBNull.Value == record["preferred_name"]) ? string.Empty : (string)record["preferred_name"];
                u.StreetAddress = (DBNull.Value == record["street_address1"]) ? string.Empty : (string)record["street_address1"];
                u.StreetAddress2 = (DBNull.Value == record["street_address2"]) ? string.Empty : (string)record["street_address2"];
                u.City = (DBNull.Value == record["city"]) ? string.Empty : (string)record["city"];
                u.State = (DBNull.Value == record["state"]) ? string.Empty : (string)record["state"];
                u.PostalCode = (DBNull.Value == record["postal_code"]) ? string.Empty : (string)record["postal_code"];
                u.MobilePhone = (DBNull.Value == record["mobile_phone"]) ? string.Empty : (string)record["mobile_phone"];
                u.WorkPhone = (DBNull.Value == record["work_phone"]) ? string.Empty : (string)record["work_phone"];
                u.HomePhone = (DBNull.Value == record["home_phone"]) ? string.Empty : (string)record["home_phone"];
                u.SchoolEmail = (DBNull.Value == record["school_email"]) ? string.Empty : (string)record["school_email"];
                u.HomeEmail = (DBNull.Value == record["home_email"]) ? string.Empty : (string)record["home_email"];
                u.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return u;

        }
    }

    class UserReader: ObjectReaderBase<User>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.users;"; }
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

        protected override MapperBase<User> GetMapper()
        {
            MapperBase<User> mapr = new UserMapper();
            return mapr;
        }
    }
}

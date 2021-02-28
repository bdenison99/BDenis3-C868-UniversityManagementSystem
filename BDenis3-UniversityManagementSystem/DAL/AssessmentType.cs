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
    class AssessmentType
    {
        // private variables for each instance
        private int _assessment_type_id;
        private string _assessment_type_name;
        private string _assessment_type_description;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int AssessmentTypeID { get => _assessment_type_id; set => _assessment_type_id = value; }
        public string AssessmentTypeName { get => _assessment_type_name; set => _assessment_type_name = value; }
        public string AssessmentTypeDescription { get => _assessment_type_description; set => _assessment_type_description = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class AssessmentTypeMapper : MapperBase<AssessmentType>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override AssessmentType Map(IDataRecord record)
        {
            AssessmentType at = new AssessmentType();

            try
            {
                at.AssessmentTypeID = (DBNull.Value == record["assessmenttype_id"]) ? 0 : (int)record["assessmenttype_id"];
                at.AssessmentTypeName = (DBNull.Value == record["name"]) ? string.Empty : (string)record["name"];
                at.AssessmentTypeDescription = (DBNull.Value == record["desc"]) ? string.Empty : (string)record["desc"];
                at.IsActive = (DBNull.Value == record["is_active"]) ? false : (bool)record["is_active"];
            }
            catch
            {

            }
            return at;

        }
    }

    class AssessmentTypeReader : ObjectReaderBase<AssessmentType>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.assessment_types;"; }
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

        protected override MapperBase<AssessmentType> GetMapper()
        {
            MapperBase<AssessmentType> mapr = new AssessmentTypeMapper();
            return mapr;
        }
    }
}

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
    class Assessment
    {
        // private variables for each instance
        private int _assessment_id;
        private string _assessment_name;
        private string _assessment_description;
        private int _max_time_allowed_minutes;
        private int _min_passing_score;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int AssessmentID { get => _assessment_id; set => _assessment_id = value; }
        public string AssessmentName { get => _assessment_name; set => _assessment_name = value; }
        public string AssessmentDescription { get => _assessment_description; set => _assessment_description = value; }
        public int MaxTimeAllowedMinutes { get => _max_time_allowed_minutes; set => _max_time_allowed_minutes = value; }
        public int MinsPassingScore { get => _min_passing_score; set => _min_passing_score = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class AssessmentMapper : MapperBase<Assessment>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override Assessment Map(IDataRecord record)
        {
            Assessment a = new Assessment();

            try
            {
                a.AssessmentID = (DBNull.Value == record["assessment_id"]) ? 0 : (int)record["assessment_id"];
                a.AssessmentName = (DBNull.Value == record["name"]) ? string.Empty : (string)record["name"];
                a.AssessmentDescription = (DBNull.Value == record["desc"]) ? string.Empty : (string)record["desc"];
                a.MaxTimeAllowedMinutes = (DBNull.Value == record["max_time_allowed"]) ? 0 : (int)record["max_time_allowed"];
                a.MinsPassingScore = (DBNull.Value == record["min_passing_score"]) ? 0 : (int)record["min_passing_score"];
                a.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return a;

        }
    }

    class AssessmentReader : ObjectReaderBase<Assessment>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.assessments;"; }
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

        protected override MapperBase<Assessment> GetMapper()
        {
            MapperBase<Assessment> mapr = new AssessmentMapper();
            return mapr;
        }
    }
}

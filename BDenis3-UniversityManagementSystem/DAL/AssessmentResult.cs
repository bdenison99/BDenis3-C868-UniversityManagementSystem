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
    class AssessmentResult
    {
        // private variables for each instance
        private int _assessment_result_id;
        private int _course_load_id;
        private int _assessment_id;
        private DateTime _assessment_date;
        private DateTime _score_published_date;
        private int _time_taken_minutes;
        private int _assessment_score;
        private string _comments;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int AssessmentResultID { get => _assessment_result_id; set => _assessment_result_id = value; }
        public int CourseLoadID { get => _course_load_id; set => _course_load_id = value; }
        public int AssessmentID { get => _assessment_id; set => _assessment_id = value; }
        public DateTime AssessmentDate { get => _assessment_date; set => _assessment_date = value; }
        public DateTime ScorePublishedDate { get => _score_published_date; set => _score_published_date = value; }
        public int TimeTaken { get => _time_taken_minutes; set => _time_taken_minutes = value; }
        public int AssessmentScore { get => _assessment_score; set => _assessment_score = value; }
        public string Comments { get => _comments; set => _comments = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }

    }

    class AssessmentResultMapper : MapperBase<AssessmentResult>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override AssessmentResult Map(IDataRecord record)
        {
            AssessmentResult ar = new AssessmentResult();

            try
            {
                ar.AssessmentResultID = (DBNull.Value == record["assessment_result_id"]) ? 0 : (int)record["assessment_result_id"];
                ar.CourseLoadID = (DBNull.Value == record["course_load_id"]) ? 0 : (int)record["course_load_id"];
                ar.AssessmentID = (DBNull.Value == record["assessment_id"]) ? 0 : (int)record["assessment_id"];
                ar.AssessmentDate = (DBNull.Value == record["assessment_date"]) ? DateTime.Now : (DateTime)record["assessment_date"];
                ar.TimeTaken = (DBNull.Value == record["time_taken"]) ? 0 : (int)record["time_taken"];
                ar.ScorePublishedDate = (DBNull.Value == record["score_published"]) ? DateTime.Now : (DateTime)record["score_published"];
                ar.AssessmentScore = (DBNull.Value == record["assessment_score"]) ? 0 : (int)record["assessment_score"];
                ar.Comments = (DBNull.Value == record["comments"]) ? string.Empty : (string)record["comments"];
                ar.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return ar;

        }
    }

    class AssessmentResultReader : ObjectReaderBase<AssessmentResult>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.assessment_results;"; }
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

        protected override MapperBase<AssessmentResult> GetMapper()
        {
            MapperBase<AssessmentResult> mapr = new AssessmentResultMapper();
            return mapr;
        }
    }

}

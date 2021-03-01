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
    class CourseAssessment
    {
        // private variables for each instance
        private int _courseassessmentid;
        private int _course_id;
        private int _assessment_id;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int CourseAssessmentID { get => _courseassessmentid; set => _courseassessmentid = value; }
        public int CourseID { get => _course_id; set => _course_id = value; }
        public int AssessmentID { get => _assessment_id; set => _assessment_id = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class CourseAssessmentMapper : MapperBase<CourseAssessment>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override CourseAssessment Map(IDataRecord record)
        {
            CourseAssessment ca = new CourseAssessment();

            try
            {
                ca.CourseAssessmentID = (DBNull.Value == record["course_assessment_id"]) ? 0 : (int)record["course_assessment_id"];
                ca.CourseID = (DBNull.Value == record["courseid"]) ? 0 : (int)record["courseid"];
                ca.AssessmentID = (DBNull.Value == record["assessmentid"]) ? 0 : (int)record["assessmentid"];
                ca.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return ca;

        }
    }

    class CourseAssessmentReader : ObjectReaderBase<CourseAssessment>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.course_assessments;"; }
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

        protected override MapperBase<CourseAssessment> GetMapper()
        {
            MapperBase<CourseAssessment> mapr = new CourseAssessmentMapper();
            return mapr;
        }
    }
}

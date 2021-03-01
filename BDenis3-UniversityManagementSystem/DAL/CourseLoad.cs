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
    class CourseLoad
    {
        // private variables for each instance
        private int _course_load_id;
        private string _course_id;
        private int _term_id;
        private string _student_id;
        private DateTime _course_start;
        private DateTime _course_end;
        private int _status_id;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int CourseLoadID { get => _course_load_id; set => _course_load_id = value; }
        public string CourseID { get => _course_id; set => _course_id = value; }
        public int TermID { get => _term_id; set => _term_id = value; }
        public string StudentID { get => _student_id; set => _student_id = value; }

        public DateTime CourseStart { get => _course_start; set => _course_start = value; }
        public DateTime CourseEnd { get => _course_end; set => _course_end = value; }
        public int StatusID { get => _status_id; set => _status_id = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }


    class CourseLoadMapper : MapperBase<CourseLoad>
    {
        protected override CourseLoad Map(IDataRecord record)
        {
            CourseLoad cl = new CourseLoad();

            try
            {
                cl.CourseLoadID = (DBNull.Value == record["course_load_id"]) ? 0 : (int)record["course_load_id"];
                cl.StudentID = (DBNull.Value == record["student_id"]) ? string.Empty : (string)record["student_id"];
                cl.CourseID = (DBNull.Value == record["course_id"]) ? string.Empty : (string)record["course_id"];
                cl.TermID = (DBNull.Value == record["term_id"]) ? 0 : (int)record["term_id"];
                cl.CourseStart = (DBNull.Value == record["appointment_start"]) ? DateTime.Now : (DateTime)record["appointment_start"];
                cl.CourseEnd = (DBNull.Value == record["appointment_end"]) ? DateTime.Now : (DateTime)record["appointment_end"];
                cl.StatusID = (DBNull.Value == record["term_id"]) ? 0 : (int)record["term_id"];
                cl.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return cl;

        }
    }

    class CourseLoadReader : ObjectReaderBase<CourseLoad>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.course_load;"; }
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

        protected override MapperBase<CourseLoad> GetMapper()
        {
            MapperBase<CourseLoad> mapr = new CourseLoadMapper();
            return mapr;
        }
    }

}

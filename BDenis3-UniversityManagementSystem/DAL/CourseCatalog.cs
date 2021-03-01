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
    class CourseCatalog
    {
        // private variables for each instance
        private string _course_id;
        private string _course_name;
        private string _course_description;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public string CourseID { get => _course_id; set => _course_id = value; }
        public string CourseName { get => _course_name; set => _course_name = value; }
        public string CourseDescription { get => _course_description; set => _course_description = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class CourseCatalogMapper : MapperBase<CourseCatalog>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override CourseCatalog Map(IDataRecord record)
        {
            CourseCatalog course = new CourseCatalog();

            try
            {
                course.CourseID = (DBNull.Value == record["course_id"]) ? string.Empty : (string)record["course_id"];
                course.CourseName = (DBNull.Value == record["course_name"]) ? string.Empty : (string)record["course_name"];
                course.CourseDescription = (DBNull.Value == record["desc"]) ? string.Empty : (string)record["desc"];
                course.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return course;

        }
    }

    class CourseCatalogReader : ObjectReaderBase<CourseCatalog>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.course_catalog;"; }
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

        protected override MapperBase<CourseCatalog> GetMapper()
        {
            MapperBase<CourseCatalog> mapr = new CourseCatalogMapper();
            return mapr;
        }
    }
}

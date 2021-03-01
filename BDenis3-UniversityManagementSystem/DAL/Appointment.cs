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
    class Appointment
    {
        // private variables for each instance
        private int _appointment_id;
        private string _student_id;
        private string _instructor_id;
        private string _course_id;
        private string _description;
        private DateTime _appt_start;
        private DateTime _appt_end;
        private string _appt_link;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int AppointmentID { get => _appointment_id; set => _appointment_id = value; }
        public string StudentID { get => _student_id; set => _student_id = value; }
        public string InstructorID { get => _instructor_id; set => _instructor_id = value; }
        public string CourseID { get => _course_id; set => _course_id = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime ApptStart { get => _appt_start; set => _appt_start = value; }
        public DateTime ApptEnd { get => _appt_end; set => _appt_end = value; }
        public string Link { get => _appt_link; set => _appt_link = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class AppointmentMapper : MapperBase<Appointment>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override Appointment Map(IDataRecord record)
        {
            Appointment a = new Appointment();

            try
            {
                a.AppointmentID = (DBNull.Value == record["appointment_id"]) ? 0 : (int)record["appointmentment_id"];
                a.StudentID = (DBNull.Value == record["student_id"]) ? string.Empty : (string)record["student_id"];
                a.CourseID = (DBNull.Value == record["course_id"]) ? string.Empty : (string)record["course_id"];
                a.InstructorID = (DBNull.Value == record["instructor_id"]) ? string.Empty : (string)record["instructor_id"];
                a.Description = (DBNull.Value == record["description"]) ? string.Empty : (string)record["description"];
                a.ApptStart = (DBNull.Value == record["appointment_start"]) ? DateTime.Now : (DateTime)record["appointment_start"];
                a.ApptEnd = (DBNull.Value == record["appointment_end"]) ? DateTime.Now : (DateTime)record["appointment_end"];
                a.Link = (DBNull.Value == record["appointment_link"]) ? string.Empty : (string)record["appointment_link"];
                a.IsActive = DBNull.Value != record["is_active"] && (bool)record["is_active"];
            }
            catch
            {

            }
            return a;

        }
    }

    class AppointmentReader : ObjectReaderBase<Appointment>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.appointments;"; }
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

        protected override MapperBase<Appointment> GetMapper()
        {
            MapperBase<Appointment> mapr = new AppointmentMapper();
            return mapr;
        }
    }
}

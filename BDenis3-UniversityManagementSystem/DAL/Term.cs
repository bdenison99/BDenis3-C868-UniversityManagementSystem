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
    class Term
    {
        // private variables for each instance
        private int _termid;
        private string _term_name;
        private DateTime _term_start;
        private DateTime _term_end;
        private string _user_id;
        private bool _isactive;


        // Property declarations for the private variables that can be modified by the application
        public int TermID { get => _termid; set => _termid = value; }
        public string TermName { get => _term_name; set => _term_name = value; }
        public DateTime TermStart { get => _term_start; set => _term_start = value; }
        public DateTime TermEnd { get => _term_end; set => _term_end = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }

    class TermMapper : MapperBase<Term>
    {
        /*
         * This is the User Mapper Class which maps a database record to a User class object instance
         */
        protected override Term Map(IDataRecord record)
        {
            Term t = new Term();

            try
            {
                t.TermID = (DBNull.Value == record["term_id"]) ? 0 : (int)record["term_id"];
                t.TermName = (DBNull.Value == record["term_title"]) ? string.Empty : (string)record["term_title"];
                t.TermStart = (DBNull.Value == record["term_start"]) ? DateTime.Now : (DateTime)record["term_start"];
                t.TermEnd = (DBNull.Value == record["legal_name"]) ? DateTime.Now : (DateTime)record["term_end"];
                t.IsActive = (DBNull.Value == record["is_active"]) ? false : (bool)record["is_active"];
            }
            catch
            {

            }
            return t;

        }
    }

    class TermReader : ObjectReaderBase<Term>
    {
        /*
         * This UserReader class is used to execute the SELECT statement in the database and map the rows
         * into a collection of users
         */
        protected override string SqlCommand
        {
            get { return "SELECT * FROM ums.term;"; }
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

        protected override MapperBase<Term> GetMapper()
        {
            MapperBase<Term> mapr = new TermMapper();
            return mapr;
        }
    }
}

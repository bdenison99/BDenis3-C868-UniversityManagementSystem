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
    abstract class MapperBase<T>
    {
        protected abstract T Map(IDataRecord dataRecord);

        public Collection<T> MapAll(IDataReader dataReader)
        {
            Collection<T> coll = new Collection<T>();

            while (dataReader.Read())
            {
                try
                {
                    coll.Add(Map(dataReader));
                }
                catch
                {
                    // Check into what exceptions might happen here, and handle them
                }
            }

            return coll;
        }
    }
}

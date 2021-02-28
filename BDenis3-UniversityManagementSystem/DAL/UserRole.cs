using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDenis3_UniversityManagementSystem
{
    public class UserRole
    {
        // private variables for each instance
        private int _userroleid;
        private string _role_name;
        private bool _isactive;

        // Property declarations for the private variables that can be modified by the application
        public int UserRoleID { get => _userroleid; set => _userroleid = value; }
        public string PreferredName { get => _role_name; set => _role_name = value; }
        public bool IsActive { get => _isactive; set => _isactive = value; }
    }
}

using System.Collections.Generic;

namespace RMS.Models
{
    public class UserDetailsDTO
    {
        public int UserSLNo { get; set; }

        public string Email { get; set; }

        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public int? ParentID { get; set; }

        public string Parent { get; set; }

        public int ChildID { get; set; }

        public string Child { get; set; }

        public bool Checked { get; set; }

        public string Enable { get; set; }
    }
}
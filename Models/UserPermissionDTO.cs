using System.Collections.Generic;

namespace RMS.Models
{
    public class UserPermissionDTO
    {
        public int Childid { get; set; }

        public string text { get; set; }

        public bool @checked { get; set; }

        public bool hasChildren { get; set; }

        public virtual List<Models.UserPermissionDTO> children { get; set; }

    }
}
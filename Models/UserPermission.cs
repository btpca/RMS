using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RMS.Models
{
    public class UserPermission
    {
        [Key]
        public int ID { get; set; }

        public int ChildID { get; set; }
        
        public int? ParentID { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }

        public int OrderNumber { get; set; }

        public int? UserSLNo { get; set; }
        [ForeignKey("UserSLNo")]
        public virtual UserInfo UserInfo { get; set; }

        public virtual Models.UserPermission Parent { get; set; }

        public virtual List<Models.UserPermission> Children { get; set; }
    }
}
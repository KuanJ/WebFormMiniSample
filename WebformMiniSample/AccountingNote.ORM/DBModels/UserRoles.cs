namespace AccountingNote.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRoles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRoles()
        {
            UserRoles1 = new HashSet<UserRoles>();
        }

        public Guid ID { get; set; }

        public Guid RoleID { get; set; }

        public Guid UserInfoID { get; set; }

        public bool? IsGrant { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Roles Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRoles> UserRoles1 { get; set; }

        public virtual UserRoles UserRoles2 { get; set; }
    }
}

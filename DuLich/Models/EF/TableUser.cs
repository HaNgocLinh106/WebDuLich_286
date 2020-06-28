namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableUser")]
    public partial class TableUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableUser()
        {
            BanTins = new HashSet<BanTin>();
        }

        [Key]
        [StringLength(8)]
        public string Username { get; set; }

        [StringLength(8)]
        public string Pass { get; set; }

        [StringLength(32)]
        public string Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanTin> BanTins { get; set; }
    }
}

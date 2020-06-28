namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            BanTins = new HashSet<BanTin>();
        }

        [Key]
        public int IDDanhMuc { get; set; }

        [StringLength(255)]
        public string TenDanhMuc { get; set; }

        public int? IDDanhMucDad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanTin> BanTins { get; set; }

        public virtual DanhMucDad DanhMucDad { get; set; }
    }
}

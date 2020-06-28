namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BinhLuan()
        {
            PhanHoiBinhLuans = new HashSet<PhanHoiBinhLuan>();
        }

        [Key]
        public int IDBinhLuan { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public int? IDBanTin { get; set; }

        [StringLength(8)]
        public string TenNguoiDung { get; set; }

        public virtual BanTin BanTin { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoiBinhLuan> PhanHoiBinhLuans { get; set; }
    }
}

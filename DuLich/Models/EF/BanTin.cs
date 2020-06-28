namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BanTin")]
    public partial class BanTin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BanTin()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        public int IDBanTin { get; set; }

        [StringLength(255)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string BanTinNgan { get; set; }

        public DateTime? NgayDang { get; set; }

        public int? SoLuotXem { get; set; }

        [StringLength(100)]
        public string ViTri { get; set; }

        public int? IDDanhMuc { get; set; }

        [StringLength(8)]
        public string Username { get; set; }

        public int? IDAnh { get; set; }

        public int? IDNoiDung { get; set; }

        public virtual Anh Anh { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual NoiDung NoiDung { get; set; }

        public virtual TableUser TableUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}

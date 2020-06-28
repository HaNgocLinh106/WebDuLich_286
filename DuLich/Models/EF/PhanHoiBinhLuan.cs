namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoiBinhLuan")]
    public partial class PhanHoiBinhLuan
    {
        [Key]
        public int IDPhanHoi { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public int? IDBinhLuan { get; set; }

        [StringLength(8)]
        public string TenNguoiDung { get; set; }

        public virtual BinhLuan BinhLuan { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}

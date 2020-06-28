namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiDung")]
    public partial class NoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NoiDung()
        {
            BanTins = new HashSet<BanTin>();
        }

        [Key]
        public int IDNoiDung { get; set; }

        [StringLength(50)]
        public string TenND_DM { get; set; }

        [Column(TypeName = "ntext")]
        public string Doan1 { get; set; }

        [Column(TypeName = "ntext")]
        public string Doan2 { get; set; }

        [Column(TypeName = "ntext")]
        public string Doan3 { get; set; }

        [Column(TypeName = "ntext")]
        public string Doan4 { get; set; }

        [Column(TypeName = "ntext")]
        public string Doan5 { get; set; }

        [Column(TypeName = "ntext")]
        public string Doan6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanTin> BanTins { get; set; }
    }
}

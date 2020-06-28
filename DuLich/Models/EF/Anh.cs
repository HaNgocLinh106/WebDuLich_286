namespace DuLich.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anh")]
    public partial class Anh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anh()
        {
            BanTins = new HashSet<BanTin>();
        }

        [Key]
        public int IDAnh { get; set; }

        [StringLength(50)]
        public string TenAnhDM { get; set; }

        [StringLength(32)]
        public string Anh1 { get; set; }

        [StringLength(32)]
        public string Anh2 { get; set; }

        [StringLength(32)]
        public string Anh3 { get; set; }

        [StringLength(32)]
        public string Anh4 { get; set; }

        [StringLength(32)]
        public string Anh5 { get; set; }

        [StringLength(32)]
        public string Anh6 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanTin> BanTins { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuLich.Models.BL
{
    public class BinhLuanModel
    {
            [Key]
            public long IDBinhLuan { get; set; }

            [Display(Name = "Tên bạn")]
            [Required(ErrorMessage = "Vui lòng nhập tên")]
            public string TenNguoiDung { set; get; }

            [Display(Name = "Bình Luận")]
            public string NoiDung { set; get; }
           
        }
}
using DuLich.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuLich.Models.Fun
{
    public class DanhMucDadF
    {
        WebDuLich db = null;
        public DanhMucDadF()
        {
            db = new WebDuLich();
        }
        public List<DanhMucDad> ListAll()
        {
            return db.DanhMucDads.ToList();
        }
        public List<DanhMuc> ListDanhMuc(long id)
        {
            var danhmuc = db.DanhMucDads.Find(id);
            return db.DanhMucs.Where(x => x.IDDanhMucDad == danhmuc.IDDanhMucDad).ToList();
        }

    }
}
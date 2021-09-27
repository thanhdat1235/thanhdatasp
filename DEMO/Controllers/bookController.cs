using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DEMO.Models;


using PagedList;
using PagedList.Mvc;
namespace DEMO.Controllers
{
    public class bookController : Controller
    {
        // GET: book
        public ActionResult Index(int ? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var sachmoi = laysachmoi(15);
            return View(sachmoi.ToPagedList(pageNum,pageSize));
        }
        QLBSDataContext data = new QLBSDataContext();
        private List<SACH> laysachmoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult nhaxuatban()
        {
            var NXB = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(NXB);
        }
        public ActionResult sptheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return PartialView(sach);
        }
        public ActionResult sptheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return PartialView(sach);
        }
        public ActionResult detail(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single());
        }
    }
}
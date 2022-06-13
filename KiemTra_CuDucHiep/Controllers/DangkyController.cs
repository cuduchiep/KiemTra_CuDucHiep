using KiemTra_CuDucHiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_CuDucHiep.Controllers
{
    public class DangkyController : Controller
    {
        // GET: Dangky
        test1DataContext data = new test1DataContext();
        public List<DangKy> Laygiohang()
        {
            List<DangKy> lstGiohang = Session["Giohang"] as List<DangKy>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<DangKy>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult GioHang()
        {
            List<DangKy> lstGiohang = Laygiohang();
           
            
            
            return View(lstGiohang);
        }
        public ActionResult GioHangPartial()
        {

            
            return PartialView();
        }
    }
}
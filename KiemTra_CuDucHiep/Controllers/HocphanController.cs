using KiemTra_CuDucHiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_CuDucHiep.Controllers
{
    public class HocphanController : Controller
    {
        // GET: Hocphan
        test1DataContext data = new test1DataContext();
        public ActionResult listHocphan()
        {
            var all_hocphan = from tt in data.HocPhans select tt;
            return View(all_hocphan);
        }
    }
}
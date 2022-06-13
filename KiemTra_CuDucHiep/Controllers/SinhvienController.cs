using KiemTra_CuDucHiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_CuDucHiep.Controllers
{
    public class SinhvienController : Controller
    {
        // GET: Sinhvien
        test1DataContext data = new  test1DataContext();
        public ActionResult Index()
        {
            var all_sinhvien = from tt in data.SinhViens select tt;
            return View(all_sinhvien);
        }
        //detail//
        public ActionResult Detail(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
        //create//
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_masv = collection["MaSV"];
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["Manganh"];
            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_masv.ToString();               
                s.HoTen = E_hoten.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh.ToString();
                s.MaNganh = E_manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        //edit//
        public ActionResult Edit(string id)
        {
            var E_sach = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_masv = data.SinhViens.First(m => m.MaSV == id);
            var E_hoten = collection["Hoten"];
            var E_gioitinh = collection["Gioitinh"];
            
            var E_ngaysinh = Convert.ToDateTime(collection["Ngaysinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["Manghanh"];
            E_masv.MaSV = id;
            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_masv.HoTen = E_hoten;
                E_masv.GioiTinh = E_gioitinh;
                E_masv.NgaySinh = E_ngaysinh;
                E_masv.Hinh = E_hinh;
                E_masv.MaNganh = E_manganh;
                
                UpdateModel(E_masv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        //delete//
        public ActionResult Delete(string id)
        {
            var D_sv = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sv);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sach = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        //dang nhap//
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            
            SinhVien kh = data.SinhViens.SingleOrDefault(n => n.MaSV == tendangnhap );

            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["HocPhan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mặt khẩu không đúng";
            }
            return RedirectToAction("Index", "Hocphan");
        }

    }
}
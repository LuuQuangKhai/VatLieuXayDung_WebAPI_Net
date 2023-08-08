using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using VatLieuXayDungWebApiApp.Models;

namespace VatLieuXayDungWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        public static List<KhachHang> dskhachhang = new List<KhachHang>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dskhachhang);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var khachhang = dskhachhang.SingleOrDefault(t => t.MaKhachHang == id);
                if (khachhang == null)
                {
                    return NotFound();
                }
                return Ok(khachhang);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(KhachHang kh)
        {
            var khachhang = new KhachHang
            {
                MaKhachHang = kh.MaKhachHang,
                TenKhachHang = kh.TenKhachHang,
                DiaChi = kh.DiaChi,
            };
            dskhachhang.Add(khachhang);
            return Ok(new { Sussess = true, Data = khachhang});
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, KhachHang kh)
        {
            try
            {
                var khachhang = dskhachhang.SingleOrDefault(t => t.MaKhachHang == id);
                if (khachhang == null)
                {
                    return NotFound();
                }
                if(kh.MaKhachHang != khachhang.MaKhachHang)
                    return BadRequest();
                khachhang.TenKhachHang = kh.TenKhachHang;
                khachhang.DiaChi = kh.DiaChi;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var khachhang = dskhachhang.SingleOrDefault(t => t.MaKhachHang == id);
                if (khachhang == null)
                {
                    return NotFound();
                }
                dskhachhang.Remove(khachhang);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

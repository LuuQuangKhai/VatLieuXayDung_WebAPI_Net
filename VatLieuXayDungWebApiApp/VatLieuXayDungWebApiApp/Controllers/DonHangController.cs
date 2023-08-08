using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using VatLieuXayDungWebApiApp.Models;

namespace VatLieuXayDungWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        public static List<DonHang> dsdonhang = new List<DonHang>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dsdonhang);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var donhang = dsdonhang.SingleOrDefault(t => t.MaDonHang == id);
                if (donhang == null)
                {
                    return NotFound();
                }
                return Ok(donhang);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(DonHang dh)
        {
            var donhang = new DonHang
            {
                MaDonHang = dh.MaDonHang,
                NgayLap = dh.NgayLap,
                MaKhachHang = dh.MaKhachHang,
            };
            dsdonhang.Add(donhang);
            return Ok(new { Sussess = true, Data = donhang });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, DonHang dh)
        {
            try
            {
                var donhang = dsdonhang.SingleOrDefault(t => t.MaDonHang == id);
                if (donhang == null)
                {
                    return NotFound();
                }
                if(donhang.MaDonHang != dh.MaDonHang)
                    return BadRequest();
                donhang.NgayLap = dh.NgayLap;
                donhang.MaKhachHang =dh.MaKhachHang;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var donhang = dsdonhang.SingleOrDefault(t => t.MaDonHang == id);
                if (donhang == null)
                {
                    return NotFound();
                }
                dsdonhang.Remove(donhang);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

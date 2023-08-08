using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatLieuXayDungWebApiApp.Models;

namespace VatLieuXayDungWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        public static List<SanPham> dssanpham = new List<SanPham>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dssanpham);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var sanpham = dssanpham.SingleOrDefault(t => t.MaSanPham == id);
                if (sanpham == null)
                    return NotFound();
                return Ok(sanpham);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(SanPham sp)
        {
            var sanpham = new SanPham
            {
                MaSanPham = sp.MaSanPham,
                TenSanPham = sp.TenSanPham,
                DonGia = sp.DonGia,
                DonViTinh = sp.DonViTinh,
            };
            dssanpham.Add(sanpham);
            return Ok(new { Sussess = true, Data = sanpham });
        }

        [HttpPut("id")]
        public IActionResult Update(int id, SanPham sp)
        {
            try
            {
                var sanpham = dssanpham.SingleOrDefault(t => t.MaSanPham == id);
                if (sanpham == null)
                    return NotFound();
                if (sp.MaSanPham != sanpham.MaSanPham)
                    return BadRequest();
                sanpham.TenSanPham = sp.TenSanPham;
                sanpham.DonGia = sp.DonGia;
                sanpham.DonViTinh = sp.DonViTinh;

                return Ok(sanpham);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var sanpham = dssanpham.SingleOrDefault(t => t.MaSanPham == id);
                if(sanpham  == null)
                {
                    return NotFound();
                }
                dssanpham.Remove(sanpham);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

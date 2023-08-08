using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatLieuXayDungWebApiApp.Models;

namespace VatLieuXayDungWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        public static List<ChiTietDonHang> dschitietdonhang = new List<ChiTietDonHang>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dschitietdonhang);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                List<ChiTietDonHang> dstheoid = new List<ChiTietDonHang>();

                foreach(var item in dschitietdonhang)
                {
                    if(item.MaDonHang == id)
                        dstheoid.Add(item);
                }
                if (dstheoid == null)
                {
                    return NotFound();
                }
                return Ok(dstheoid);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{madonhang}/{masanpham}")]
        public IActionResult GetByIdId(int madonhang, int masanpham)
        {
            try
            {
                var chitiet = dschitietdonhang.SingleOrDefault(t => t.MaDonHang == madonhang && t.MaSanPham == masanpham);

                if (chitiet == null)
                {
                    return NotFound();
                }
                return Ok(chitiet);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ChiTietDonHang ctdh)
        {
            var chitiet = new ChiTietDonHang
            {
                MaDonHang = ctdh.MaDonHang,
                SoLuong = ctdh.SoLuong,
                MaSanPham = ctdh.MaSanPham
            };
            dschitietdonhang.Add(chitiet);
            return Ok(new { Sussess = true, Data = chitiet });
        }

        [HttpPut("{madonhang}/{masanpham}")]
        public IActionResult Update(int madonhang,int masanpham, ChiTietDonHang ctdh)
        {
            try
            {
                var chitiet = dschitietdonhang.SingleOrDefault(t => t.MaDonHang == madonhang && t.MaSanPham == masanpham);

                if (chitiet == null)
                {
                    return NotFound();
                }
                if(chitiet.MaDonHang != ctdh.MaDonHang || chitiet.MaSanPham != ctdh.MaSanPham)
                {
                    return BadRequest();
                }
                chitiet.SoLuong = ctdh.SoLuong;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{madonhang}/{masanpham}")]
        public IActionResult Delete(int madonhang,int masanpham)
        {
            try
            {
                var chitiet = dschitietdonhang.SingleOrDefault(t => t.MaDonHang == madonhang && t.MaSanPham == masanpham);

                if (chitiet == null)
                {
                    return NotFound();
                }
                dschitietdonhang.Remove(chitiet);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

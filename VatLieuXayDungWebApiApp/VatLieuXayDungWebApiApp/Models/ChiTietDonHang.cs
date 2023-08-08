using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VatLieuXayDungWebApiApp.Models
{
    public class ChiTietDonHang
    {
        public int SoLuong { get; set; }
        [ForeignKey("SanPham")]
        public string MaSanPham { get; set; }
        public virtual SanPham SanPhams { get; set; }
        [ForeignKey("DonHang")]
        public string MaDonHang { get; set; }
        public virtual DonHang DonHangs { get; set; }
    }
}

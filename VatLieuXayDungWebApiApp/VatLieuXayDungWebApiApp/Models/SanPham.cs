using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace VatLieuXayDungWebApiApp.Models
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string DonViTinh { get; set; }
        public double DonGia { get; set; }

        public ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }
    }
}

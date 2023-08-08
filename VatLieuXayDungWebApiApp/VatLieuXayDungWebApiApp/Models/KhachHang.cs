using System.ComponentModel.DataAnnotations;

namespace VatLieuXayDungWebApiApp.Models
{
    public class KhachHang
    {
        public int MaKhachHang { get; set; }    
        public string TenKhachHang { get; set; }
        public string DiaChi { get;set; }
        public ICollection<DonHang>? DonHangs { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VatLieuXayDungWebApiApp.Models
{
    public class DonHang
    {
        public int MaDonHang { get; set; }
        public DateTime NgayLap { get; set; }

        [ForeignKey("KhachHang")]
        public string MaKhachHang { get; set; }
        public virtual KhachHang KhachHangs { get; set; }

        public ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }
    }
}

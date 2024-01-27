using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuyenTapListVoiObj
{
    internal class Nguoi
    {
        // danh sách thuộc tính
        public string SoCCCD { get; set; } // prop tab tab
        public string Ten { get; set; }
        public DateTime DoB { get; set; } // Date Of Birth
        public string DiaChi { get; set; }
        public Nguoi()
        {
        }
        public Nguoi(string soCCCD, string ten, DateTime doB, string diaChi)
        {
            SoCCCD = soCCCD;
            Ten = ten;
            DoB = doB;
            DiaChi = diaChi;
        }
        public void InThongTin()
        {
            Console.WriteLine($"Tôi tên là: {Ten}, CCCD: {SoCCCD}");
            Console.WriteLine($"Tôi {DateTime.Now.Year - DoB.Year} tuổi, Tôi ở {DiaChi}");
            // Year hiện tại - Year ngày sinh
        }
    }
}

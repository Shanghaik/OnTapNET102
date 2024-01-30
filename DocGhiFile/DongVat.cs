using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGhiFile
{
    internal class DongVat
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public int SoChan { get; set; }
        public DongVat()
        {
        }
        public DongVat(string ten, string moTa, int soChan)
        {
            Ten = ten;
            MoTa = moTa;
            SoChan = soChan;
        }
        public void InThongTin()
        {
            Console.WriteLine($"Tên: {Ten}, Mô tả: {MoTa} có số chân {SoChan}");
        }
        
    }
}

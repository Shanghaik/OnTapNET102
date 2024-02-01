using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO
{
    internal class Sinhvien
    {
        public int ID { get; set; }
        public int IDLop { get; set; }
        public string Name { get; set; }
        public float Mark { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public void InThongTin()
        {
            Console.WriteLine($"Tên {Name}, Điểm: {Mark}");
        }
    }
}
